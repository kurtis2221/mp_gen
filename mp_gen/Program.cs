using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Net.Sockets;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;

namespace mp_gen
{
    public class Form1 : Form
    {
        public const string TITLE = "Multiplayer Generator Client v1.1";

        string game_exe;

        int BUFFER_SIZE;
        ushort PORT;
        int THD_SLEEP;

        Pointer[] game_addrs;
        bool baseaddr;

        TextBox tb_ip;
        Button bt_connect;

        StreamReader sr;
        StreamWriter sw;

        Thread thd, thd2;
        TcpClient cli;
        Socket sock;
        MemoryEdit.Memory mem;
        Process game;
        byte id;

#if DEBUG
        Label lb_player;
        Label lb_network;
        System.Windows.Forms.Timer tmr;
#endif

        public Form1()
        {
            try
            {
#if DEBUG
                //Change dir to game dir
                Environment.CurrentDirectory = "E:\\Driver";
#endif
                string[] data, data2;
                uint tmp;
                bool statchk;
                sr = new StreamReader(GlobalInfo.CFG_FILE);
                //PORT
                ushort.TryParse(sr.ReadLine(), out PORT);
                //MAX_PLAYERS, ignore
                sr.ReadLine();
                //BUFFER_SIZE (largest)
                int.TryParse(sr.ReadLine(), NumberStyles.HexNumber, CultureInfo.CurrentCulture, out BUFFER_SIZE);
                BUFFER_SIZE += GlobalInfo.BUFFER_DATA;
                //THD_SLEEP
                int.TryParse(sr.ReadLine(), out THD_SLEEP);
                //Game
                game_exe = sr.ReadLine();
                //States
                uint.TryParse(sr.ReadLine(), out tmp);
                statchk = tmp > 1;
                //Addresses
                game_addrs = new Pointer[tmp];
                Pointer gaddr;
                PtrAddress ptr;
                for (int st = 0; st < game_addrs.Length; st++)
                {
                    game_addrs[st] = new Pointer();
                    gaddr = game_addrs[st];
                    //Status address
                    if (statchk)
                    {
                        FillPointers(sr.ReadLine(), ref gaddr.st_addr, out gaddr.st_ptr_offs);
                        data = sr.ReadLine().Split(GlobalInfo.CFG_DELIM);
                        gaddr.st_data_len = (ushort)data.Length;
                        gaddr.st_val = new byte[gaddr.st_data_len];
                        for (int i = 0; i < gaddr.st_data_len; i++)
                            byte.TryParse(data[i], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out gaddr.st_val[i]);
                    }
                    else
                    {
                        gaddr.st_data_len = 0;
                        sr.ReadLine();
                        sr.ReadLine();
                    }
                    //Number of addresses
                    uint.TryParse(sr.ReadLine(), out tmp);
                    gaddr.addresses = new PtrAddress[GlobalInfo.ADDR_TYPES, tmp];
                    gaddr.data = new PtrData[tmp];
                    //Address loading
                    for (int typ = 0; typ < GlobalInfo.ADDR_TYPES; typ++)
                    {
                        data = sr.ReadLine().Split(GlobalInfo.CFG_DELIM);
                        for (int adr = 0; adr < data.Length; adr++)
                        {
                            gaddr.addresses[typ, adr] = new PtrAddress();
                            gaddr.data[adr] = new PtrData();
                            ptr = gaddr.addresses[typ, adr];
                            //Pointers + offsets
                            FillPointers(data[adr], ref ptr.addr, out ptr.ptr_offs);
                        }
                    }
                    data = sr.ReadLine().Split(GlobalInfo.CFG_DELIM);
                    data2 = sr.ReadLine().Split(GlobalInfo.CFG_DELIM);
                    for (int adr = 0; adr < data.Length; adr++)
                    {
                        //Data length
                        ushort.TryParse(data[adr], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out gaddr.data[adr].data_len);
                        //Address offsets
                        uint.TryParse(data2[adr], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out gaddr.data[adr].adrr_offs);
                    }
                }
                //Use base address
                bool.TryParse(sr.ReadLine(), out baseaddr);
                sr.Close();
            }
            catch (Exception ex)
            {
                MsgBox(ex);
            }
            Text = TITLE;
#if DEBUG
            ClientSize = new Size(320, 200);
#else
            ClientSize = new Size(320, 48);
#endif
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            tb_ip = new TextBox();
            tb_ip.Bounds = new Rectangle(12, 12, 128, 24);
            tb_ip.MaxLength = 15;
            //Load last IP address
            if (File.Exists(GlobalInfo.lastip_file))
            {
                sr = new StreamReader(GlobalInfo.lastip_file);
                tb_ip.Text = sr.ReadLine();
                sr.Close();
            }
            Controls.Add(tb_ip);
            bt_connect = new Button();
            bt_connect.Text = "Connect";
            bt_connect.Bounds = new Rectangle(ClientRectangle.Right - 140, 12, 128, 24);
            bt_connect.Click += bt_connect_Click;
            Controls.Add(bt_connect);
#if DEBUG
            lb_player = new Label();
            lb_player.Bounds = new Rectangle(0, 40, 160, 160);
            lb_player.BackColor = Color.LightGreen;
            Controls.Add(lb_player);
            lb_network = new Label();
            lb_network.Bounds = new Rectangle(160, 40, 160, 160);
            lb_network.BackColor = Color.LightBlue;
            Controls.Add(lb_network);
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000;
            tmr.Tick += TmrDebugInfo;
#endif
        }

        protected override void OnClosed(EventArgs e)
        {
            if (game != null && !game.HasExited)
                game.Kill();
            Environment.Exit(0);
        }

        void bt_connect_Click(object sender, EventArgs e)
        {
            bt_connect.Enabled = false;
            tb_ip.Enabled = false;
            try
            {
                byte[] buffer = new byte[1];
                cli = new TcpClient(tb_ip.Text, PORT);
                cli.Client.Receive(buffer);
                id = buffer[0];
                sw = new StreamWriter(GlobalInfo.lastip_file, false, Encoding.Default);
                sw.Write(tb_ip.Text);
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + " - " + ex.Message, Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                bt_connect.Enabled = true;
                tb_ip.Enabled = true;
                return;
            }
            game = new Process();
            game.StartInfo.FileName = game_exe;
            game.StartInfo.WorkingDirectory = Path.GetDirectoryName(game_exe);
            game.Start();
            mem = new MemoryEdit.Memory();
            while (!mem.Attach(game, 0x001F0FFF)) ;
            if (baseaddr)
                Pointer.baseaddr = (uint)game.MainModule.BaseAddress.ToInt64();
            Pointer.mem = mem;
            sock = cli.Client;
            thd = new Thread(new ThreadStart(Rec));
            thd.Start();
            thd2 = new Thread(new ThreadStart(Snd));
            thd2.Start();
#if DEBUG
            tmr.Start();
#endif
        }

        void Rec()
        {
            try
            {
                byte[] buffer = new byte[BUFFER_SIZE];
                byte[] data = new byte[BUFFER_SIZE - GlobalInfo.BUFFER_DATA];
                uint address, offset;
                int idx, len;
                Pointer ptr;
                while (true)
                {
                    sock.Receive(buffer);
                    if (buffer[0] >= id)
                        buffer[0]--;

                    idx = GlobalInfo.BUFFER_DATA;
                    ptr = game_addrs[buffer[1]];
                    for (int adr = 0; adr < ptr.addresses.GetLength(1); adr++)
                    {
                        address = ptr.GetAddr(GlobalInfo.ADDR_NET, adr);
                        offset = ptr.data[adr].adrr_offs;
                        len = ptr.data[adr].data_len;
                        Array.Copy(buffer, idx, data, 0, len);
                        mem.WriteByte(address + offset * buffer[0], data, len);
                        idx += len;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex);
                if (game != null && !game.HasExited)
                    game.Kill();
                Environment.Exit(0);
            }
        }

        void Snd()
        {
            try
            {
                byte[] buffer = new byte[BUFFER_SIZE - GlobalInfo.BUFFER_DIDX];
                byte[] data;
                uint address;
                int idx, len;
                Pointer ptr;
                while (true)
                {
                    Thread.Sleep(THD_SLEEP);
                    for (int st = 0; st < game_addrs.Length; st++)
                    {
                        ptr = game_addrs[st];
                        if (ptr.GetState())
                        {
                            idx = GlobalInfo.BUFFER_DIDX;
                            buffer[0] = (byte)st;
                            for (int adr = 0; adr < ptr.addresses.GetLength(1); adr++)
                            {
                                address = ptr.GetAddr(GlobalInfo.ADDR_PLAYER, adr);
                                len = ptr.data[adr].data_len;
                                data = mem.ReadBytes(address, len);
                                Array.Copy(data, 0, buffer, idx, len);
                                idx += len;
                            }
                            sock.Send(buffer);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex);
                if (game != null && !game.HasExited)
                    game.Kill();
                Environment.Exit(0);
            }
        }

#if DEBUG
        void TmrDebugInfo(object sender, EventArgs e)
        {
            lb_player.Text = null;
            lb_network.Text = null;
            for (int i = 0; i < game_addrs.Length; i++)
            {
                lb_player.Text += "State " + i + ": \n";
                lb_network.Text += "State " + i + ": \n";
                for (int addr = 0; addr < game_addrs[i].addresses.GetLength(1); addr++)
                {
                    lb_player.Text += game_addrs[i].GetAddr(GlobalInfo.ADDR_PLAYER, addr).ToString("X") + "\n";
                    lb_network.Text += game_addrs[i].GetAddr(GlobalInfo.ADDR_NET, addr).ToString("X") + "\n";
                }
                lb_player.Text += "\n";
                lb_network.Text += "\n";
            }
        }
#endif

        void FillPointers(string line, ref uint addr, out uint[] offs)
        {
            uint tmp;
            string[] ptr = line.Split(GlobalInfo.PTR_DELIM);
            uint.TryParse(ptr[0], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out tmp);
            addr = tmp;
            offs = null;
            if (ptr.Length > 1)
            {
                offs = new uint[ptr.Length - 1];
                for (int i = 0; i < offs.Length; i++)
                {
                    uint.TryParse(ptr[i + 1], NumberStyles.HexNumber, CultureInfo.CurrentCulture, out tmp);
                    offs[i] = tmp;
                }
            }
        }

        void MsgBox(Exception ex)
        {
            MessageBox.Show(ex.Source + " - " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    class Pointer
    {
        public static MemoryEdit.Memory mem;
        public static uint baseaddr;

        public uint st_addr;
        public uint[] st_ptr_offs = null;
        public ushort st_data_len;
        public byte[] st_val;
        public PtrAddress[,] addresses;
        public PtrData[] data;

        public uint GetAddr(int typ, int id)
        {
            PtrAddress addr;
            addr = addresses[typ, id];
            uint tmp = addr.addr + baseaddr;
            if (addr.ptr_offs != null)
            {
                tmp = mem.Read(addr.addr) + addr.ptr_offs[0];
                for (int i2 = 1; i2 < addr.ptr_offs.Length; i2++)
                    tmp = mem.Read(tmp) + addr.ptr_offs[i2];
            }
            return tmp;
        }

        public bool GetState()
        {
            if (st_data_len == 0) return true;

            uint tmp = st_addr + baseaddr;
            if (st_ptr_offs != null)
            {
                tmp = mem.Read(st_addr) + st_ptr_offs[0];
                for (int i = 1; i < st_ptr_offs.Length; i++)
                    tmp = mem.Read(tmp) + st_ptr_offs[i];
            }
            byte[] tarr = mem.ReadBytes(tmp, st_data_len);
            for (int i = 0; i < st_data_len; i++)
            {
                if (tarr[i] != st_val[i])
                    return false;
            }
            return true;
        }
    }

    class PtrAddress
    {
        public uint addr;
        public uint[] ptr_offs;
    }

    class PtrData
    {
        public uint adrr_offs;
        public ushort data_len;
    }

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (!File.Exists(GlobalInfo.CFG_FILE))
            {
                MessageBox.Show(GlobalInfo.CFG_FILE + " not found.", Form1.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class GlobalInfo
    {
        public const string CFG_FILE = "mp_gen.ini";
        public const string lastip_file = "mp_gen.txt";
        public const char CFG_DELIM = ';';
        public const char PTR_DELIM = '>';

        public const int ADDR_TYPES = 2;
        public const int ADDR_PLAYER = 0;
        public const int ADDR_NET = 1;

        public const int BUFFER_DATA = 2;
        public const int BUFFER_DIDX = BUFFER_DATA - 1;

        private GlobalInfo() { }
    }
}