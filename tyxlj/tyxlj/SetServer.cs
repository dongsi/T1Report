using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace tyxlj
{
    public partial class SetServer : Form
    {
        public SetServer()
        {
            InitializeComponent();
            
            this.tBServer.Text = ConfigurationManager.AppSettings["Server"].ToString();
            this.tBPort.Text = ConfigurationManager.AppSettings["Port"].ToString();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Configuration cfa = ConfigurationManager.
    OpenExeConfiguration(ConfigurationUserLevel.None);

            cfa.AppSettings.Settings["Server"].Value = this.tBServer.Text;
            cfa.AppSettings.Settings["Port"].Value = this.tBPort.Text;
            cfa.Save();
            MessageBox.Show("保存成功");
            this.Close();
        }
    }
}
