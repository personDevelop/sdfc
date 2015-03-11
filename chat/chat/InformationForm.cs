using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CCWin.Win32;
using CCWin.Win32.Const;
using System.Diagnostics;

namespace ChatClient
{
    public partial class InformationForm : CCSkinMain
    {
        private AuthorityEntity.IM.MsgEntity contract;

        public InformationForm()
        {
            InitializeComponent();

            this.skinLabel2.Text = "GG 2013 即时通讯系统\n高仿QQ界面\n语音视频聊天";
        }

        public InformationForm(AuthorityEntity.IM.MsgEntity contract)
            : this()
        {
            // TODO: Complete member initialization
            this.contract = contract;
            if (!string.IsNullOrWhiteSpace(contract.MsgTitle))
            {
                this.Text = contract.MsgTitle;
            }
            skinLabel2.Text = contract.MsgContent;
        }

        //窗口加载时
        private void FrmInformation_Load(object sender, EventArgs e)
        {
            //初始化窗口出现位置
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            this.PointToScreen(p);
            this.Location = p;
            NativeMethods.AnimateWindow(this.Handle, 130, AW.AW_SLIDE + AW.AW_VER_NEGATIVE);//开始窗体动画
        }

        //倒计时6秒关闭弹出窗
        private void timShow_Tick(object sender, EventArgs e)
        {
            //鼠标不在窗体内时
            if (!this.Bounds.Contains(Cursor.Position))
            {
                this.Close();
            }
        }


    }
}
