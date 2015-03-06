using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIMClient.Skin;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace WIMClient.Skin
{
    //public partial class FriendControl : UserControl
    //{
    //    private Graphics g = null;
    //    private Bitmap bgImg = null;
    //    private Bitmap headImg = null;
    //    private Bitmap headBorder = null;

    //    private int x = 8;
    //    private int y = 8;

    //    private Bitmap HeadBmp = ResClass.GetImgRes("big1");
    //    private Friend _friendInfo;
    //    private Font f = null;

    //    public delegate void SelectedEventHandler(Friend sender);
    //    public event SelectedEventHandler Selecting;

    //    public delegate void OpenChatEventHandler(Friend sender);
    //    public event OpenChatEventHandler OpenChat;

    //    public delegate void ShowContextMenuEventHandler(FriendControl sender, MouseEventArgs e);
    //    public event ShowContextMenuEventHandler ShowContextMenu;
    //    private bool _IsSelect = false;

    //    public FriendControl()
    //    {
    //        bgImg = null;
    //        this.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
    //        this.BackColor = Color.Transparent;

    //        if (Environment.OSVersion.Version.Major >= 6)
    //        {
    //            f = new Font("微软雅黑", 9F, FontStyle.Regular);
    //        }
    //        else
    //        {
    //            f = new Font("宋体", 9F, FontStyle.Regular);
    //        }

    //        this.SetStyle(ControlStyles.UserPaint, true);
    //        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    //        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    //    }

    //    public Friend FriendInfo
    //    {
    //        get
    //        {
    //            return _friendInfo;
    //        }
    //        set
    //        {
    //            _friendInfo = value;
    //            ChangeInfo(_friendInfo);
    //            this.Invalidate();
    //        }
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        g = e.Graphics;
    //        if (bgImg != null)
    //        {
    //            g.DrawImage(bgImg, new Rectangle(0, 0, this.Width, 1), 0, 0, bgImg.Width, 1, GraphicsUnit.Pixel);
    //            g.DrawImage(bgImg, new Rectangle(0, 1, 1, this.Height - 2), 0, 1, 1, bgImg.Height - 2, GraphicsUnit.Pixel);
    //            g.DrawImage(bgImg, new Rectangle(1, 1, this.Width - 2, this.Height - 2), 1, 1, bgImg.Width - 2, bgImg.Height - 2, GraphicsUnit.Pixel);
    //            g.DrawImage(bgImg, new Rectangle(this.Width - 1, 1, 1, this.Height - 2), bgImg.Width - 1, 1, 1, bgImg.Height - 2, GraphicsUnit.Pixel);
    //            g.DrawImage(bgImg, new Rectangle(0, this.Height - 1, this.Width, 1), 0, bgImg.Height - 1, bgImg.Width, 1, GraphicsUnit.Pixel);
    //        }
    //        if (!FriendInfo.IsSysHead)
    //            headBorder = ResClass.GetImgRes("Padding4Normal");
    //        if (headBorder != null)
    //        {
    //            g.DrawImage(headBorder, new Rectangle(4, 4, 48, 48), 0, 0, 48, 48, GraphicsUnit.Pixel);
    //        }
    //        g.DrawImage(headImg, new Rectangle(x, y, 40, 40), 0, 0, 40, 40, GraphicsUnit.Pixel);
            
    //        g.DrawString(FriendInfo.NikeName, f, new SolidBrush(Color.FromArgb(240, 0, 0, 0)), 60, 7);
    //        g.DrawString(FriendInfo.Description, f, new SolidBrush(Color.FromArgb(100, 0, 0, 0)), 60, 28);
    //    }

    //    protected override void OnMouseEnter(EventArgs e)
    //    {
    //        if (!IsSelected)
    //        {
    //            bgImg = ResClass.GetImgRes("friendTitlebg");
    //            headBorder = ResClass.GetImgRes("Padding4Select");
    //            this.Invalidate();
    //        }
            
    //    }

    //    protected override void OnMouseLeave(EventArgs e)
    //    {
    //        if (!IsSelected)
    //        {
    //            bgImg = null;
    //            headBorder = null;
    //            this.Invalidate();
    //        }
    //    }

    //    protected override void OnMouseClick(MouseEventArgs e)
    //    {
    //        if (e.Button == MouseButtons.Left)
    //        {
    //            if (!IsSelected)
    //            {
    //                IsSelected = true;
    //                bgImg = ResClass.GetImgRes("friendTitleOpenbg");
    //                headBorder = ResClass.GetImgRes("Padding4Press");
    //                this.Invalidate();
    //                if (Selecting != null)
    //                    Selecting(this.FriendInfo);
    //            }
    //        }
    //        else 
    //        {
    //            if (ShowContextMenu != null)
    //                ShowContextMenu(this, e);
    //        }
    //    }

    //    protected override void OnMouseDoubleClick(MouseEventArgs e)
    //    {
    //        base.OnMouseDoubleClick(e);
    //        if (e.Button == MouseButtons.Left)
    //        {
    //            if (!IsSelected)
    //            {
    //                bgImg = ResClass.GetImgRes("friendTitleOpenbg");
    //                headBorder = ResClass.GetImgRes("Padding4Press");
    //                this.Invalidate();
    //            }
    //            if (OpenChat != null)
    //                OpenChat(this.FriendInfo);
    //        }
    //    }

    //    protected override void OnResize(EventArgs e)
    //    {
    //        base.OnResize(e);
    //        int Rgn = Win32.CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, 5, 5);
    //        Win32.SetWindowRgn(this.Handle, Rgn, true);
    //        this.Invalidate();
    //    }

    //    public void SelectCurrent(bool flag) 
    //    {
    //        if (flag) 
    //        {
    //            OnMouseClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
    //        } 
    //        else 
    //        {
    //            OnMouseLeave(null);
    //        }
    //    }

    //    public void Call(int Jsec)
    //    {
    //        if (Jsec % 2 == 0)
    //        {
    //            x = 8;
    //            y = 6;
    //        }
    //        else
    //        {
    //            x = 7;
    //            y = 5;
    //        }
    //        this.Invalidate(new Rectangle(7, 5, 41, 41));
    //    }

    //    public void UpdateState(UserInfo Info)
    //    {
    //        //ChangeInfo(Info);
    //        this.Invalidate(new Rectangle(7, 5, 41, 41));
    //    }

    //    private void ChangeInfo(Friend friend)
    //    {
    //        headImg = ResClass.GetHead(friend.HeadIMG);
    //        switch (friend.State)
    //            {
    //                case 0:
    //                    //headImg = SkinUtil.ProcImage(Bmp, -15, -1, 100);
    //                    break;
    //                case 1:
    //                    //headImg = Bmp;
    //                    break;
    //                case 2:
    //                    //headImg = Bmp;
    //                    break;
    //                case 3:
    //                    //headImg = Bmp;
    //                    break;
    //                case 4:
    //                    //headImg = Bmp;
    //                    break;
    //                case 5:
    //                    //if (Info.qq != Program.userInfo.qq)
    //                    //{
    //                    //    nImg = romoveRGB(img);
    //                    //}
    //                    //else 
    //                    //{

    //                    //}
    //                    break;
    //            }
    //    }

    //    internal void Selected()
    //    {
    //        OnMouseClick(new MouseEventArgs(MouseButtons.Left,1,0,0,0));
    //    }

    //    public bool IsSelected
    //    {
    //        get
    //        {
    //            return _IsSelect;
    //        }
    //        set
    //        {
    //            _IsSelect = value;
    //            if (value)
    //            {
    //                bgImg = ResClass.GetImgRes("friendTitleOpenbg");
    //                headBorder = ResClass.GetImgRes("Padding4Press");
    //            }
    //            else
    //            {
    //                bgImg = null;
    //                headBorder = ResClass.GetImgRes("Padding4Normal");
    //            }
    //            this.Invalidate();
    //        }
    //    }
    //}
}
