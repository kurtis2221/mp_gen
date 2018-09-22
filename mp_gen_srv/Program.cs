using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Globalization;
using mp_gen;

namespace mp_gen_srv
{
    class Program
    {
        const string TITLE = "Multiplayer Generator Server v1.1";
        static ushort PORT;
        static int BUFFER_SIZE;

        static StreamReader sr;
        static TcpListener srv;

        static byte slots, count;
        static Socket[] plsck;
        static Thread[] plthd;
        static string[] plip;

        static void Main(string[] args)
        {
            Console.Title = TITLE;
            if (!File.Exists(GlobalInfo.CFG_FILE))
            {
                Console.WriteLine(GlobalInfo.CFG_FILE + " not found.");
                Console.ReadKey(true);
                return;
            }
            byte maxpl;
            sr = new StreamReader(GlobalInfo.CFG_FILE, Encoding.Default);
            //PORT
            ushort.TryParse(sr.ReadLine(), out PORT);
            byte.TryParse(sr.ReadLine(), out maxpl);
            if (maxpl < 2) maxpl = 2;
            else if (maxpl > 16) maxpl = 16;
            //BUFFER_SIZE (largest)
            int.TryParse(sr.ReadLine(), NumberStyles.HexNumber, CultureInfo.CurrentCulture, out BUFFER_SIZE);
            BUFFER_SIZE += GlobalInfo.BUFFER_DIDX;
            sr.Close();
            Console.Write("Players(2-" + maxpl + "):");
            if (!byte.TryParse(Console.ReadLine(), out slots))
                slots = 4;
            if (slots < 2) slots = 2;
            else if (slots > maxpl) slots = maxpl;
            Console.Title = TITLE + " (0/" + slots + ")";
            Console.WriteLine("Server running");
            srv = new TcpListener(System.Net.IPAddress.Any, PORT);
            srv.Start();
            Rec();
        }

        static void Rec()
        {
            plsck = new Socket[slots];
            plthd = new Thread[slots];
            plip = new string[slots];
            count = 0;
            string ip;
            Socket tmp;
            byte i;
            while (true)
            {
                Thread.Sleep(1);
                if (count >= slots) continue;
                tmp = srv.AcceptSocket();
                ip = ((System.Net.IPEndPoint)tmp.RemoteEndPoint).Address.ToString();
                for (i = 0; i < slots; i++)
                {
                    if (plsck[i] == null)
                    {
                        Console.WriteLine("Player connected id:" + i + " (" + ip + ")");
                        plip[i] = ip;
                        ip = null;
                        plsck[i] = tmp;
                        tmp = null;
                        try
                        {
                            plsck[i].Send(new byte[] { i });
                        }
                        catch { }
                        plthd[i] = new Thread(() => Snd(i));
                        plthd[i].Start();
                        count++;
                        Console.Title = TITLE + " (" + count + "/" + slots + ")";
                        break;
                    }
                }
            }
        }

        static void Snd(byte id)
        {
            try
            {
                byte[] buffer = new byte[BUFFER_SIZE];
                byte[] output = new byte[BUFFER_SIZE + 1];
                byte i;
                while (true)
                {
                    Thread.Sleep(1);
                    plsck[id].Receive(buffer);
                    Array.Copy(buffer, 0, output, 1, BUFFER_SIZE);
                    output[0] = id;
                    for (i = 0; i < slots; i++)
                        if (plsck[i] != null && i != id)
                            plsck[i].Send(output);
                }
            }
            catch
            {
                Console.WriteLine("Player disconnected id:" + id + " (" + plip[id] + ")");
                count--;
                Console.Title = TITLE + " (" + count + "/" + slots + ")";
                plsck[id].Close();
                plsck[id] = null;
                plthd[id].Abort();
                plthd[id] = null;
                plip[id] = null;
                GC.Collect();
            }
        }
    }
}