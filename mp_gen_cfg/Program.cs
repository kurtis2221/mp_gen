using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using mp_gen;

namespace mp_gen_cfg
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}