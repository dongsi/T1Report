namespace tyxlj
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.bLogin = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tBLoginName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(42, 177);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(75, 23);
            this.bLogin.TabIndex = 0;
            this.bLogin.Text = "登录";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(171, 177);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 1;
            this.bClose.Text = "关闭";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名";
            // 
            // tBLoginName
            // 
            this.tBLoginName.Location = new System.Drawing.Point(75, 59);
            this.tBLoginName.Name = "tBLoginName";
            this.tBLoginName.Size = new System.Drawing.Size(173, 21);
            this.tBLoginName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "密码";
            // 
            // tBPassword
            // 
            this.tBPassword.Location = new System.Drawing.Point(75, 105);
            this.tBPassword.Name = "tBPassword";
            this.tBPassword.PasswordChar = '*';
            this.tBPassword.Size = new System.Drawing.Size(173, 21);
            this.tBPassword.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 226);
            this.ControlBox = false;
            this.Controls.Add(this.tBPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBLoginName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bLogin);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBLoginName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBPassword;
    }
}

