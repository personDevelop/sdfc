namespace WIMClient.Skin
{
    partial class RegisterUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUserID = new WIMClient.Skin.QQtextBox();
            this.txtNickName = new WIMClient.Skin.QQtextBox();
            this.loginButton1 = new WIMClient.Skin.LoginButton();
            this.txtPsw = new WIMClient.Skin.QQtextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtRePsw = new WIMClient.Skin.QQtextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.Color.White;
            this.txtUserID.Icon = null;
            this.txtUserID.Location = new System.Drawing.Point(71, 83);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(137, 21);
            this.txtUserID.TabIndex = 24;
            // 
            // txtNickName
            // 
            this.txtNickName.BackColor = System.Drawing.Color.White;
            this.txtNickName.Icon = null;
            this.txtNickName.Location = new System.Drawing.Point(71, 125);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(137, 21);
            this.txtNickName.TabIndex = 25;
            // 
            // loginButton1
            // 
            this.loginButton1.BackColor = System.Drawing.Color.Transparent;
            this.loginButton1.Location = new System.Drawing.Point(73, 263);
            this.loginButton1.Name = "loginButton1";
            this.loginButton1.Size = new System.Drawing.Size(115, 27);
            this.loginButton1.TabIndex = 26;
            this.loginButton1.Texts = "注册";
          
            this.loginButton1.Click += new System.EventHandler(this.loginButton1_Click);
            // 
            // txtPsw
            // 
            this.txtPsw.BackColor = System.Drawing.Color.White;
            this.txtPsw.Icon = null;
            this.txtPsw.Location = new System.Drawing.Point(71, 169);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.Size = new System.Drawing.Size(137, 21);
            this.txtPsw.TabIndex = 27;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.White;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(17, 86);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(41, 12);
            this.linkLabel1.TabIndex = 28;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "用户ID";
            // 
            // txtRePsw
            // 
            this.txtRePsw.BackColor = System.Drawing.Color.White;
            this.txtRePsw.Icon = null;
            this.txtRePsw.Location = new System.Drawing.Point(71, 213);
            this.txtRePsw.Name = "txtRePsw";
            this.txtRePsw.Size = new System.Drawing.Size(137, 21);
            this.txtRePsw.TabIndex = 29;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.White;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(17, 134);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(29, 12);
            this.linkLabel2.TabIndex = 30;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "昵称";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.White;
            this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel3.LinkColor = System.Drawing.Color.Black;
            this.linkLabel3.Location = new System.Drawing.Point(17, 172);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(29, 12);
            this.linkLabel3.TabIndex = 31;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "密码";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.BackColor = System.Drawing.Color.White;
            this.linkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel4.LinkColor = System.Drawing.Color.Black;
            this.linkLabel4.Location = new System.Drawing.Point(17, 216);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(53, 12);
            this.linkLabel4.TabIndex = 32;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "确认密码";
            // 
            // RegisterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 376);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.txtRePsw);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtPsw);
            this.Controls.Add(this.loginButton1);
            this.Controls.Add(this.txtNickName);
            this.Controls.Add(this.txtUserID);
            this.Name = "RegisterUser";
            this.Text = "注册新用户";
            this.Controls.SetChildIndex(this.txtUserID, 0);
            this.Controls.SetChildIndex(this.txtNickName, 0);
            this.Controls.SetChildIndex(this.loginButton1, 0);
            this.Controls.SetChildIndex(this.txtPsw, 0);
            this.Controls.SetChildIndex(this.linkLabel1, 0);
            this.Controls.SetChildIndex(this.txtRePsw, 0);
            this.Controls.SetChildIndex(this.linkLabel2, 0);
            this.Controls.SetChildIndex(this.linkLabel3, 0);
            this.Controls.SetChildIndex(this.linkLabel4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QQtextBox txtUserID;
        private QQtextBox txtNickName;
        private LoginButton loginButton1;
        private QQtextBox txtPsw;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private QQtextBox txtRePsw;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel4;
    }
}