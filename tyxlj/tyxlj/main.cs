using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tyxlj
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 数据库配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetServer serverset=new SetServer();
            serverset.ShowDialog();

        }
    }
}
