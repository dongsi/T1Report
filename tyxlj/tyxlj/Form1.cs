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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();//关闭登录窗口,退出系统
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            this.Close();//关闭登录窗口，设置返回结果
            this.DialogResult = DialogResult.OK;
        }
    }
}
