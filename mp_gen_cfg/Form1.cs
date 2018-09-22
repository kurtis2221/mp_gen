using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace mp_gen_cfg
{
    public partial class Form1 : Form
    {
        public const string TITLE = "Multiplayer Generator Editor v1.1";

        Status[] data;
        System.Globalization.NumberStyles hex_num;
        int cur_stat, cur_addr;

        public Form1()
        {
            InitializeComponent();
            Text = TITLE;
            hex_num = System.Globalization.NumberStyles.HexNumber;
            data = new Status[(int)dt_nr_stat.Maximum];
            Status.addr_s = (int)dt_nr_addr.Maximum;
            for (int i = 0; i < data.Length; i++)
                data[i] = new Status();
            cur_stat = (int)dt_st_cur.Value - 1;
            cur_addr = (int)dt_st_addrc.Value - 1;
        }

        //Data to controls
        void dt_st_cur_ValueChanged(object sender, EventArgs e)
        {
            cur_stat = (int)dt_st_cur.Value - 1;
            Status tmp = data[cur_stat];
            dt_st_addr.Text = tmp.st_addr.ToString("X8");
            dt_st_offs.Rows.Clear();
            for (int i = 0; i < tmp.st_offs.Count; i++)
            {
                dt_st_offs.Rows.Add();
                dt_st_offs[0, i].Value = tmp.st_offs[i].ToString("X");
            }
            dt_st_ptr.Checked = tmp.st_ptr;
            dt_st_val.Text = null;
            for (int i = 0; i < tmp.st_val.Count; i++)
                dt_st_val.Text += tmp.st_val[i].ToString("X2");
            dt_nr_addr.Value = tmp.nr_addr;
            //Reset to first address
            if (dt_st_addrc.Value != 1)
                dt_st_addrc.Value = 1;
            else
                dt_st_addrc_ValueChanged(null, null);
        }

        void dt_st_addrc_ValueChanged(object sender, EventArgs e)
        {
            cur_addr = (int)dt_st_addrc.Value - 1;
            Address tmp = data[cur_stat].addr[cur_addr];
            dt_pl_addr.Text = tmp.pl_addr.ToString("X8");
            dt_pl_ptr.Checked = tmp.pl_ptr;
            dt_pl_offs.Rows.Clear();
            for (int i = 0; i < tmp.pl_offs.Count; i++)
            {
                dt_pl_offs.Rows.Add();
                dt_pl_offs[0, i].Value = tmp.pl_offs[i].ToString("X");
            }
            dt_nt_addr.Text = tmp.nt_addr.ToString("X8");
            dt_nt_ptr.Checked = tmp.nt_ptr;
            dt_nt_offs.Rows.Clear();
            for (int i = 0; i < tmp.nt_offs.Count; i++)
            {
                dt_nt_offs.Rows.Add();
                dt_nt_offs[0, i].Value = tmp.nt_offs[i].ToString("X");
            }
            dt_buffer.Value = tmp.dt_size;
            dt_offset.Text = tmp.dt_offs.ToString("X");
        }

        //Pointer data
        void dt_st_ptr_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == dt_st_ptr)
                data[cur_stat].st_ptr =
                dt_st_offs.Visible =
                dt_st_offs.Enabled =
                    dt_st_ptr.Checked;
            else if (sender == dt_pl_ptr)
                data[cur_stat].addr[cur_addr].pl_ptr =
                dt_pl_offs.Visible =
                dt_pl_offs.Enabled =
                    dt_pl_ptr.Checked;
            else //if (sender == dt_nt_ptr)
                data[cur_stat].addr[cur_addr].nt_ptr =
                dt_nt_offs.Visible =
                dt_nt_offs.Enabled =
                    dt_nt_ptr.Checked;
        }

        //Data from controls
        void dt_st_addr_Validated(object sender, EventArgs e)
        {
            try
            {
                Status tmp = data[cur_stat];
                Address tmp2 = tmp.addr[cur_addr];
                string input = ((TextBox)sender).Text;
                if (sender == dt_st_val)
                {
                    tmp.st_val.Clear();
                    for (int i = 0; i < input.Length; i += 2)
                        tmp.st_val.Add(
                            byte.Parse(input.Substring(i, 2), hex_num));
                    return;
                }
                uint val = uint.Parse(input, hex_num);
                if (sender == dt_st_addr)
                    tmp.st_addr = val;
                else if (sender == dt_pl_addr)
                    tmp2.pl_addr = val;
                else if (sender == dt_nt_addr)
                    tmp2.nt_addr = val;
                else if (sender == dt_offset)
                    tmp2.dt_offs = val;
            }
            catch (Exception ex)
            {
                ErrMsg(ex);
            }
        }

        void dt_st_offs_Validated(object sender, EventArgs e)
        {
            try
            {
                Status tmp = data[cur_stat];
                Address tmp2 = tmp.addr[cur_addr];
                DataGridView dgw = (DataGridView)sender;
                string input;
                List<uint> lst;

                if (dgw == dt_st_offs)
                    lst = tmp.st_offs;
                else if (dgw == dt_pl_offs)
                    lst = tmp2.pl_offs;
                else //if (dgw == dt_nt_offs)
                    lst = tmp2.nt_offs;

                lst.Clear();
                for (int i = 0; i < dgw.Rows.Count - 1; i++)
                {
                    input = (string)dgw[0, i].Value;
                    if (input != null)
                        lst.Add(uint.Parse(input, hex_num));
                }
            }
            catch (Exception ex)
            {
                ErrMsg(ex);
            }
        }

        void dt_buffer_Validated(object sender, EventArgs e)
        {
            if (sender == dt_buffer)
                data[cur_stat].addr[cur_addr].dt_size = (uint)dt_buffer.Value;
            else if (sender == dt_nr_addr)
                data[cur_stat].nr_addr = (int)dt_nr_addr.Value;
        }

        //Load
        void bt_load_Click(object sender, EventArgs e)
        {
            try
            {
                ResetValues();
                string[] spl;
                string[] tmp_pl;
                string[] tmp_nt;
                string[] tmp_size;
                string[] tmp_offs;
                int stats;
                int addrs;
                Status tmp;
                Address tmp2;
                StreamReader sr = new StreamReader(mp_gen.GlobalInfo.CFG_FILE, Encoding.Default);
                dt_port.Value = int.Parse(sr.ReadLine());
                dt_maxpl.Value = int.Parse(sr.ReadLine());
                sr.ReadLine(); //Max buffer size is recalculated
                dt_update.Value = int.Parse(sr.ReadLine());
                dt_game.Text = sr.ReadLine();
                //Nr. of states
                stats = int.Parse(sr.ReadLine());
                dt_nr_stat.Value = stats;
                for (int i = 0; i < stats; i++)
                {
                    //States
                    tmp = data[i];
                    FillPointers(sr.ReadLine(), ref tmp.st_addr, ref tmp.st_ptr, tmp.st_offs);
                    spl = sr.ReadLine().Split(mp_gen.GlobalInfo.CFG_DELIM);
                    for (int i2 = 0; i2 < spl.Length; i2++)
                        tmp.st_val.Add(byte.Parse(spl[i2], hex_num));
                    //Nr. of addresses
                    addrs = int.Parse(sr.ReadLine());
                    tmp.nr_addr = addrs;
                    //Addresses
                    tmp_pl = sr.ReadLine().Split(mp_gen.GlobalInfo.CFG_DELIM);
                    tmp_nt = sr.ReadLine().Split(mp_gen.GlobalInfo.CFG_DELIM);
                    tmp_size = sr.ReadLine().Split(mp_gen.GlobalInfo.CFG_DELIM);
                    tmp_offs = sr.ReadLine().Split(mp_gen.GlobalInfo.CFG_DELIM);
                    for (int i2 = 0; i2 < addrs; i2++)
                    {
                        tmp2 = tmp.addr[i2];
                        //Player
                        FillPointers(tmp_pl[i2], ref tmp2.pl_addr, ref tmp2.pl_ptr, tmp2.pl_offs);
                        //Network
                        FillPointers(tmp_nt[i2], ref tmp2.nt_addr, ref tmp2.nt_ptr, tmp2.nt_offs);
                        //Buffer
                        tmp2.dt_size = uint.Parse(tmp_size[i2], hex_num);
                        //Offset
                        tmp2.dt_offs = uint.Parse(tmp_offs[i2], hex_num);
                    }
                }
                //Use base addresss
                dt_base.Checked = bool.Parse(sr.ReadLine());
                sr.Close();
                //Call event to update controls
                dt_st_cur_ValueChanged(null, null);
                MessageBox.Show("Config file loaded.", TITLE,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrMsg(ex);
            }
        }

        //Save
        void bt_save_Click(object sender, EventArgs e)
        {
            if (dt_game.Text.Length == 0)
            {
                MessageBox.Show("Game name not filled out.", TITLE,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string[] tmp_data = new string[4];
                int stats = (int)dt_nr_stat.Value;
                int addrs;
                uint maxbuff = 0;
                Status tmp;
                Address tmp2;
                StreamWriter sw = new StreamWriter(mp_gen.GlobalInfo.CFG_FILE, false, Encoding.Default);
                sw.WriteLine(dt_port.Value);
                sw.WriteLine(dt_maxpl.Value);
                for (int i = 0; i < stats; i++)
                {
                    tmp = data[i];
                    addrs = tmp.nr_addr;
                    for (int i2 = 0; i2 < addrs; i2++)
                        if (maxbuff < tmp.addr[i2].dt_size)
                            maxbuff = tmp.addr[i2].dt_size;
                }
                sw.WriteLine(maxbuff.ToString("X"));
                sw.WriteLine(dt_update.Value);
                sw.WriteLine(dt_game.Text);
                //Nr. of states
                sw.WriteLine(stats);
                for (int i = 0; i < stats; i++)
                {
                    tmp = data[i];
                    //States
                    sw.Write(tmp.st_addr.ToString("X8"));
                    if (tmp.st_ptr && tmp.st_offs.Count > 0)
                    {
                        for (int i2 = 0; i2 < tmp.st_offs.Count; i2++)
                            sw.Write(mp_gen.GlobalInfo.PTR_DELIM + tmp.st_offs[i2].ToString("X"));
                    }
                    sw.WriteLine();
                    if (tmp.st_val.Count > 0)
                    {
                        sw.Write(tmp.st_val[0].ToString("X2"));
                        for (int i2 = 1; i2 < tmp.st_val.Count; i2++)
                            sw.Write(mp_gen.GlobalInfo.CFG_DELIM + tmp.st_val[i2].ToString("X2"));
                        sw.WriteLine();
                    }
                    else
                        sw.WriteLine("00");
                    //Nr. of addresses
                    addrs = tmp.nr_addr;
                    sw.WriteLine(addrs);
                    //Addresses
                    for (int i2 = 0; i2 < tmp_data.Length; i2++)
                        tmp_data[i2] = null;
                    for (int i2 = 0; i2 < addrs; i2++)
                    {
                        tmp2 = tmp.addr[i2];
                        //Player
                        tmp_data[0] += tmp.addr[i2].pl_addr.ToString("X8");
                        if (tmp2.pl_ptr && tmp2.pl_offs.Count > 0)
                        {
                            for (int i3 = 0; i3 < tmp2.pl_offs.Count; i3++)
                                tmp_data[0] += mp_gen.GlobalInfo.PTR_DELIM + tmp2.pl_offs[i3].ToString("X");
                        }
                        tmp_data[0] += mp_gen.GlobalInfo.CFG_DELIM;
                        //Network
                        tmp_data[1] += tmp.addr[i2].nt_addr.ToString("X8");
                        if (tmp2.nt_ptr && tmp2.nt_offs.Count > 0)
                        {
                            for (int i3 = 0; i3 < tmp2.nt_offs.Count; i3++)
                                tmp_data[1] += mp_gen.GlobalInfo.PTR_DELIM + tmp2.nt_offs[i3].ToString("X");
                        }
                        tmp_data[1] += mp_gen.GlobalInfo.CFG_DELIM;
                        //Buffer
                        tmp_data[2] += tmp2.dt_size.ToString("X") + mp_gen.GlobalInfo.CFG_DELIM;
                        //Offset
                        tmp_data[3] += tmp2.dt_offs.ToString("X") + mp_gen.GlobalInfo.CFG_DELIM;
                    }
                    for (int i2 = 0; i2 < tmp_data.Length; i2++)
                        sw.WriteLine(tmp_data[i2].Remove(tmp_data[i2].Length - 1));
                }
                //Use base address
                sw.Write(dt_base.Checked);
                sw.Close();
                MessageBox.Show("Config file saved.", TITLE,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrMsg(ex);
            }
        }

        //Other functions
        void ErrMsg(Exception ex)
        {
            MessageBox.Show(ex.Source + " - " + ex.Message, TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void FillPointers(string line, ref uint addr, ref bool point, List<uint> offs)
        {
            uint tmp;
            string[] ptr = line.Split(mp_gen.GlobalInfo.PTR_DELIM);
            uint.TryParse(ptr[0], hex_num, System.Globalization.CultureInfo.CurrentCulture, out tmp);
            addr = tmp;
            point = ptr.Length > 1;
            if (point)
            {
                for (int i = 1; i < ptr.Length; i++)
                {
                    uint.TryParse(ptr[i], hex_num, System.Globalization.CultureInfo.CurrentCulture, out tmp);
                    offs.Add(tmp);
                }
            }
        }

        void ResetValues()
        {
            Status tmp;
            Address tmp2;
            dt_port.Value = 7777;
            dt_update.Value = 40;
            dt_game.Text = null;
            dt_base.Checked = false;
            for (int i = 0; i < data.Length; i++)
            {
                tmp = data[i];
                tmp.nr_addr = 1;
                tmp.st_addr = 0;
                tmp.st_offs.Clear();
                tmp.st_ptr = false;
                tmp.st_val.Clear();
                for (int i2 = 0; i2 < data.Length; i2++)
                {
                    tmp2 = tmp.addr[i2];
                    tmp2.pl_addr = 0;
                    tmp2.pl_ptr = false;
                    tmp2.pl_offs.Clear();
                    tmp2.nt_addr = 0;
                    tmp2.nt_ptr = false;
                    tmp2.nt_offs.Clear();
                    tmp2.dt_size = 12;
                    tmp2.dt_offs = 0;
                }
            }
            //Call event to update controls
            dt_st_cur_ValueChanged(null, null);
        }

        void bt_reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset?", TITLE,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
                ResetValues();
        }
    }

    class Status
    {
        public static int addr_s;

        public int nr_addr;

        public uint st_addr;
        public bool st_ptr;
        public List<uint> st_offs;
        public List<byte> st_val;

        public Address[] addr;

        public Status()
        {
            addr = new Address[addr_s];
            for (int i = 0; i < addr.Length; i++)
                addr[i] = new Address();
            st_offs = new List<uint>();
            st_val = new List<byte>();
            nr_addr = 1;
        }
    }

    class Address
    {
        public uint pl_addr;
        public bool pl_ptr;
        public List<uint> pl_offs;
        public uint nt_addr;
        public bool nt_ptr;
        public List<uint> nt_offs;
        public uint dt_size;
        public uint dt_offs;

        public Address()
        {
            pl_offs = new List<uint>();
            nt_offs = new List<uint>();
            dt_size = 12;
        }
    }
}