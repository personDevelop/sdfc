namespace ChatClient
{
    partial class EmotionForm
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
            this.SuspendLayout();
            // 
            // EmotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = global::ChatClient.Properties.Resources.allbtn_highlight;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(380, 280);
            this.ControlBox = false;
            this.Mobile = CCWin.MobileStyle.None;
            this.Name = "EmotionForm";
            this.ShowBorder = false;
            this.ShowDrawIcon = false;
            this.ShowInTaskbar = false;
            this.SkinOpacity = 0.9D;
            this.TopMost = true;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FaceEmotionBoard_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

    }
}