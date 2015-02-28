using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace tyxlj
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 log=new Form1();
            log.ShowDialog();
            if (log.DialogResult == DialogResult.OK)
            {
                Application.Run(new main());
            }
        }
    }
}
