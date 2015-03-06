using WIMClient.Skin;
namespace WIMClient.Skin
{
    partial class QQChatForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QQChatForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ButtonClose = new System.Windows.Forms.PictureBox();
            this.ButtonMax = new System.Windows.Forms.PictureBox();
            this.ButtonMin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMin)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 4000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.BackColor = System.Drawing.Color.Transparent;
            this.ButtonClose.Location = new System.Drawing.Point(486, 0);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(38, 18);
            this.ButtonClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ButtonClose.TabIndex = 21;
            this.ButtonClose.TabStop = false;
            this.ButtonClose.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonClose_Paint);
            this.ButtonClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonClose_MouseClick);
            this.ButtonClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonClose_MouseDown);
            this.ButtonClose.MouseEnter += new System.EventHandler(this.ButtonClose_MouseEnter);
            this.ButtonClose.MouseLeave += new System.EventHandler(this.ButtonClose_MouseLeave);
            this.ButtonClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonClose_MouseUp);
            // 
            // ButtonMax
            // 
            this.ButtonMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMax.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMax.Location = new System.Drawing.Point(461, 0);
            this.ButtonMax.Name = "ButtonMax";
            this.ButtonMax.Size = new System.Drawing.Size(25, 18);
            this.ButtonMax.TabIndex = 23;
            this.ButtonMax.TabStop = false;
            this.ButtonMax.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonMax_Paint);
            this.ButtonMax.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonMax_MouseClick);
            this.ButtonMax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMax_MouseDown);
            this.ButtonMax.MouseEnter += new System.EventHandler(this.ButtonMax_MouseEnter);
            this.ButtonMax.MouseLeave += new System.EventHandler(this.ButtonMax_MouseLeave);
            this.ButtonMax.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMax_MouseUp);
            // 
            // ButtonMin
            // 
            this.ButtonMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMin.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMin.Location = new System.Drawing.Point(436, 0);
            this.ButtonMin.Name = "ButtonMin";
            this.ButtonMin.Size = new System.Drawing.Size(25, 18);
            this.ButtonMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ButtonMin.TabIndex = 20;
            this.ButtonMin.TabStop = false;
            this.ButtonMin.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonMin_Paint);
            this.ButtonMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonMin_MouseClick);
            this.ButtonMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMin_MouseDown);
            this.ButtonMin.MouseEnter += new System.EventHandler(this.ButtonMin_MouseEnter);
            this.ButtonMin.MouseLeave += new System.EventHandler(this.ButtonMin_MouseLeave);
            this.ButtonMin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMin_MouseUp);
            // 
            // QQChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(187)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(524, 454);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonMax);
            this.Controls.Add(this.ButtonMin);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(240, 400);
            this.Name = "QQChatForm";
            this.Text = "QQ2010";
            ((System.ComponentModel.ISupportInitialize)(this.ButtonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox ButtonMin;
        private System.Windows.Forms.PictureBox ButtonMax;
        private System.Windows.Forms.PictureBox ButtonClose;

    }
}