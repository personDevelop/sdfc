namespace ChatClient
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panelHeadImage = new CCWin.SkinControl.SkinPanel();
            this.skinButton_State = new CCWin.SkinControl.SkinButton();
            this.buttonLogin = new CCWin.SkinControl.SkinButton();
            this.imgLoadding = new System.Windows.Forms.PictureBox();
            this.checkBoxRememberPwd = new CCWin.SkinControl.SkinCheckBox();
            this.checkBoxAutoLogin = new CCWin.SkinControl.SkinCheckBox();
            this.textBoxPwd = new CCWin.SkinControl.SkinTextBox();
            this.textBoxId = new CCWin.SkinControl.SkinTextBox();
            this.buttonId = new CCWin.SkinControl.SkinButton();
            this.panelHeadImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadding)).BeginInit();
            this.textBoxPwd.SuspendLayout();
            this.textBoxId.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeadImage
            // 
            this.panelHeadImage.BackColor = System.Drawing.Color.Transparent;
            this.panelHeadImage.BackgroundImage = global::ChatClient.Properties.Resources.log;
            this.panelHeadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHeadImage.Controls.Add(this.skinButton_State);
            this.panelHeadImage.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelHeadImage.DownBack = null;
            this.panelHeadImage.Location = new System.Drawing.Point(32, 128);
            this.panelHeadImage.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeadImage.MouseBack = null;
            this.panelHeadImage.Name = "panelHeadImage";
            this.panelHeadImage.NormlBack = null;
            this.panelHeadImage.Radius = 4;
            this.panelHeadImage.Size = new System.Drawing.Size(85, 85);
            this.panelHeadImage.TabIndex = 12;
            // 
            // skinButton_State
            // 
            this.skinButton_State.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_State.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.skinButton_State.BackRectangle = new System.Drawing.Rectangle(4, 4, 4, 4);
            this.skinButton_State.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(90)))), ((int)(((byte)(147)))));
            this.skinButton_State.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_State.DownBack = null;
            this.skinButton_State.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton_State.ImageWidth = 12;
            this.skinButton_State.Location = new System.Drawing.Point(67, 67);
            this.skinButton_State.Margin = new System.Windows.Forms.Padding(0);
            this.skinButton_State.MouseBack = null;
            this.skinButton_State.Name = "skinButton_State";
            this.skinButton_State.NormlBack = null;
            this.skinButton_State.Size = new System.Drawing.Size(18, 18);
            this.skinButton_State.TabIndex = 10;
            this.skinButton_State.Tag = "2";
            this.skinButton_State.UseVisualStyleBackColor = false;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonLogin.BackRectangle = new System.Drawing.Rectangle(50, 23, 50, 23);
            this.buttonLogin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(90)))), ((int)(((byte)(147)))));
            this.buttonLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.buttonLogin.Create = true;
            this.buttonLogin.DownBack = global::ChatClient.Properties.Resources.button_login_down;
            this.buttonLogin.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.buttonLogin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.buttonLogin.ForeColor = System.Drawing.Color.Black;
            this.buttonLogin.Location = new System.Drawing.Point(99, 244);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLogin.MouseBack = global::ChatClient.Properties.Resources.button_login_hover;
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.NormlBack = global::ChatClient.Properties.Resources.button_login_normal;
            this.buttonLogin.Palace = true;
            this.buttonLogin.Size = new System.Drawing.Size(185, 49);
            this.buttonLogin.TabIndex = 13;
            this.buttonLogin.Text = "登        录";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // imgLoadding
            // 
            this.imgLoadding.Image = ((System.Drawing.Image)(resources.GetObject("imgLoadding.Image")));
            this.imgLoadding.Location = new System.Drawing.Point(1, 243);
            this.imgLoadding.Margin = new System.Windows.Forms.Padding(0);
            this.imgLoadding.Name = "imgLoadding";
            this.imgLoadding.Size = new System.Drawing.Size(377, 2);
            this.imgLoadding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoadding.TabIndex = 18;
            this.imgLoadding.TabStop = false;
            this.imgLoadding.Visible = false;
            // 
            // checkBoxRememberPwd
            // 
            this.checkBoxRememberPwd.AutoSize = true;
            this.checkBoxRememberPwd.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxRememberPwd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checkBoxRememberPwd.DefaultCheckButtonWidth = 15;
            this.checkBoxRememberPwd.DownBack = null;
            this.checkBoxRememberPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxRememberPwd.ForeColor = System.Drawing.Color.Black;
            this.checkBoxRememberPwd.LightEffect = false;
            this.checkBoxRememberPwd.Location = new System.Drawing.Point(133, 192);
            this.checkBoxRememberPwd.MouseBack = null;
            this.checkBoxRememberPwd.Name = "checkBoxRememberPwd";
            this.checkBoxRememberPwd.NormlBack = ((System.Drawing.Image)(resources.GetObject("checkBoxRememberPwd.NormlBack")));
            this.checkBoxRememberPwd.SelectedDownBack = null;
            this.checkBoxRememberPwd.SelectedMouseBack = null;
            this.checkBoxRememberPwd.SelectedNormlBack = null;
            this.checkBoxRememberPwd.Size = new System.Drawing.Size(75, 21);
            this.checkBoxRememberPwd.TabIndex = 19;
            this.checkBoxRememberPwd.Text = "记住密码";
            this.checkBoxRememberPwd.UseVisualStyleBackColor = false;
            // 
            // checkBoxAutoLogin
            // 
            this.checkBoxAutoLogin.AutoSize = true;
            this.checkBoxAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxAutoLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checkBoxAutoLogin.DefaultCheckButtonWidth = 15;
            this.checkBoxAutoLogin.DownBack = null;
            this.checkBoxAutoLogin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.checkBoxAutoLogin.ForeColor = System.Drawing.Color.Black;
            this.checkBoxAutoLogin.LightEffect = false;
            this.checkBoxAutoLogin.Location = new System.Drawing.Point(214, 192);
            this.checkBoxAutoLogin.MouseBack = null;
            this.checkBoxAutoLogin.Name = "checkBoxAutoLogin";
            this.checkBoxAutoLogin.NormlBack = ((System.Drawing.Image)(resources.GetObject("checkBoxAutoLogin.NormlBack")));
            this.checkBoxAutoLogin.SelectedDownBack = null;
            this.checkBoxAutoLogin.SelectedMouseBack = null;
            this.checkBoxAutoLogin.SelectedNormlBack = null;
            this.checkBoxAutoLogin.Size = new System.Drawing.Size(75, 21);
            this.checkBoxAutoLogin.TabIndex = 20;
            this.checkBoxAutoLogin.Text = "自动登录";
            this.checkBoxAutoLogin.UseVisualStyleBackColor = false;
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.BackColor = System.Drawing.Color.Transparent;
            this.textBoxPwd.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textBoxPwd.Icon = ((System.Drawing.Image)(resources.GetObject("textBoxPwd.Icon")));
            this.textBoxPwd.IconIsButton = true;
            this.textBoxPwd.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxPwd.Location = new System.Drawing.Point(133, 161);
            this.textBoxPwd.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPwd.MinimumSize = new System.Drawing.Size(0, 28);
            this.textBoxPwd.MouseBack = null;
            this.textBoxPwd.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.NormlBack = null;
            this.textBoxPwd.Padding = new System.Windows.Forms.Padding(5, 5, 120, 5);
            this.textBoxPwd.Size = new System.Drawing.Size(185, 28);
            // 
            // textBoxPwd.BaseText
            // 
            this.textBoxPwd.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPwd.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPwd.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textBoxPwd.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.textBoxPwd.SkinTxt.Name = "BaseText";
            this.textBoxPwd.SkinTxt.PasswordChar = '●';
            this.textBoxPwd.SkinTxt.Size = new System.Drawing.Size(60, 18);
            this.textBoxPwd.SkinTxt.TabIndex = 0;
            this.textBoxPwd.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textBoxPwd.SkinTxt.WaterText = "密码";
            this.textBoxPwd.TabIndex = 38;
            // 
            // textBoxId
            // 
            this.textBoxId.BackColor = System.Drawing.Color.Transparent;
            this.textBoxId.Icon = null;
            this.textBoxId.IconIsButton = false;
            this.textBoxId.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxId.Location = new System.Drawing.Point(133, 128);
            this.textBoxId.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxId.MinimumSize = new System.Drawing.Size(28, 28);
            this.textBoxId.MouseBack = null;
            this.textBoxId.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.NormlBack = null;
            this.textBoxId.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.textBoxId.Size = new System.Drawing.Size(185, 28);
            // 
            // textBoxId.BaseText
            // 
            this.textBoxId.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxId.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxId.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textBoxId.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.textBoxId.SkinTxt.Name = "BaseText";
            this.textBoxId.SkinTxt.Size = new System.Drawing.Size(152, 18);
            this.textBoxId.SkinTxt.TabIndex = 0;
            this.textBoxId.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textBoxId.SkinTxt.WaterText = "登录用户";
            this.textBoxId.SkinTxt.TextChanged += new System.EventHandler(this.textBoxId_SkinTxt_TextChanged);
            this.textBoxId.TabIndex = 39;
            // 
            // buttonId
            // 
            this.buttonId.BackColor = System.Drawing.Color.White;
            this.buttonId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonId.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(90)))), ((int)(((byte)(147)))));
            this.buttonId.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.buttonId.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonId.DownBack = global::ChatClient.Properties.Resources.login_inputbtn_down;
            this.buttonId.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.buttonId.Location = new System.Drawing.Point(294, 130);
            this.buttonId.Margin = new System.Windows.Forms.Padding(0);
            this.buttonId.MouseBack = global::ChatClient.Properties.Resources.login_inputbtn_highlight;
            this.buttonId.Name = "buttonId";
            this.buttonId.NormlBack = global::ChatClient.Properties.Resources.login_inputbtn_normal;
            this.buttonId.Size = new System.Drawing.Size(22, 24);
            this.buttonId.TabIndex = 40;
            this.buttonId.UseVisualStyleBackColor = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = global::ChatClient.Properties.Resources.blue;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(90)))), ((int)(((byte)(147)))));
            this.BackPalace = global::ChatClient.Properties.Resources.texture;
            this.BorderPalace = global::ChatClient.Properties.Resources.BackPalace;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(379, 292);
            this.CloseBoxSize = new System.Drawing.Size(39, 20);
            this.CloseDownBack = global::ChatClient.Properties.Resources.btn_close_down;
            this.CloseMouseBack = global::ChatClient.Properties.Resources.btn_close_highlight;
            this.CloseNormlBack = global::ChatClient.Properties.Resources.btn_close_disable;
            this.Controls.Add(this.buttonId);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.textBoxPwd);
            this.Controls.Add(this.checkBoxRememberPwd);
            this.Controls.Add(this.checkBoxAutoLogin);
            this.Controls.Add(this.imgLoadding);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.panelHeadImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaxDownBack = global::ChatClient.Properties.Resources.btn_max_down;
            this.MaximizeBox = false;
            this.MaxMouseBack = global::ChatClient.Properties.Resources.btn_max_highlight;
            this.MaxNormlBack = global::ChatClient.Properties.Resources.btn_max_normal;
            this.MiniDownBack = global::ChatClient.Properties.Resources.btn_mini_down;
            this.MiniMouseBack = global::ChatClient.Properties.Resources.btn_mini_highlight;
            this.MiniNormlBack = global::ChatClient.Properties.Resources.btn_mini_normal;
            this.MiniSize = new System.Drawing.Size(28, 20);
            this.Name = "frmLogin";
            this.RestoreDownBack = global::ChatClient.Properties.Resources.btn_restore_down;
            this.RestoreMouseBack = global::ChatClient.Properties.Resources.btn_restore_highlight;
            this.RestoreNormlBack = global::ChatClient.Properties.Resources.btn_restore_normal;
            this.SysBottomDown = global::ChatClient.Properties.Resources.btn_set_press;
            this.SysBottomMouse = global::ChatClient.Properties.Resources.btn_set_hover;
            this.SysBottomNorml = global::ChatClient.Properties.Resources.btn_set_normal;
            this.SysBottomToolTip = "设置";
            this.SysBottomVisibale = true;
            this.SysBottomClick += new CCWin.CCSkinMain.SysBottomEventHandler(this.Form1_SysBottomClick);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelHeadImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadding)).EndInit();
            this.textBoxPwd.ResumeLayout(false);
            this.textBoxPwd.PerformLayout();
            this.textBoxId.ResumeLayout(false);
            this.textBoxId.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinPanel panelHeadImage;
        private CCWin.SkinControl.SkinButton skinButton_State;
        private CCWin.SkinControl.SkinButton buttonLogin;
        private System.Windows.Forms.PictureBox imgLoadding;
        private CCWin.SkinControl.SkinCheckBox checkBoxRememberPwd;
        private CCWin.SkinControl.SkinCheckBox checkBoxAutoLogin;
        private CCWin.SkinControl.SkinTextBox textBoxPwd;
        private CCWin.SkinControl.SkinTextBox textBoxId;
        private CCWin.SkinControl.SkinButton buttonId;


    }
}

