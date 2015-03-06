//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace WIMClient
{
    [ToolboxItem(false)]
    public class Group : Panel
    {
        public Group(string GroupID, string GroupName, params User[] Users)
        {
            this.groupID = GroupID;
            this.groupName = GroupName;
            this.Users = new Users(this);

            //样式控制
            base.AutoScroll = false;
            base.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            base.BackColor = Color.White;

            this.AllowDrop = true;

            //屏闭系统绘制
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;

            //来消息闪烁
            Timer timerText = new Timer();
            timerText.Interval = 300;
            timerText.Tick += delegate
            {
                this.drawText = !this.drawText;
                this.Invalidate(new Rectangle(18, 0, this.Width - 18, 21));
            };

            Common.ShowOnlineOnlyChanged += delegate { this.resetLocation(); };

            //在不在线的排序
            this.onlineList = new List<User>();
            this.offlineList = new List<User>();

            //重命名文本输入框
            this.textbox = new TextBox();
            this.textbox.Location = new Point(18, 0);
            this.textbox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            this.textbox.Visible = false;
            this.Controls.Add(this.textbox);
            this.textbox.LostFocus += delegate { this.EndEdit(); };
            this.textbox.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                    this.EndEdit();
            };

            //用户组处理
            this.Users.UserCountChanged += delegate
            {
                this.Invalidate(new Rectangle(18, 0, this.Width - 18, 21));
            };
            this.Users.UserAdded += delegate(User user)
            {
                this.Controls.Add(user);

                user.Messages.CountChanged += delegate
                {
                    if (user.Messages.Count > 0)
                    {
                        timerText.Enabled = true;
                    }
                    else
                    {
                        timerText.Enabled = false;
                        this.drawText = true;
                        this.Invalidate(new Rectangle(18, 0, this.Width - 18, 21));
                    }

                    if (this.UserCalling != null)
                        this.UserCalling(user);
                };

                if (this.expanded)
                    this.resetLocation();
            };
            this.Users.UserRemoved += delegate(User user)
            {
                user.Messages.Clear();//把这个好友的消息清掉，这样SlidingBar不会画头像。比如有人发消息来，这时不查看消息，而把这个人删了，那么SildingBar就不应该再画这个人的头像了
                this.onlineList.Remove(user);
                this.offlineList.Remove(user);

                this.Controls.Remove(user);

                user.OnlineStateChanged -= User_OnlineStateChanged;//删好友时，状态事件脱链。

                this.resetLocation();
            };

            if (Users != null)
                for (int i = 0; i < Users.Length; i++)
                    this.Users.Add(Users[i]);
        }

        public Dictionary<string, User> usersDic = null;

        public Group(string GroupID, string GroupName)
        {
            this.groupID = GroupID;
            this.groupName = GroupName;
            this.Users = new Users(this);            

            //样式控制
            base.AutoScroll = false;
            base.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            base.BackColor = Color.White;

            this.AllowDrop = true;

            //屏闭系统绘制
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;
           

            Common.ShowOnlineOnlyChanged += delegate { this.resetLocation(); };

            //在不在线的排序
            this.onlineList = new List<User>();
            this.offlineList = new List<User>();

            //重命名文本输入框
            this.textbox = new TextBox();
            this.textbox.Location = new Point(18, 0);
            this.textbox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            this.textbox.Visible = false;
            this.Controls.Add(this.textbox);
            this.textbox.LostFocus += delegate { this.EndEdit(); };
            this.textbox.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                    this.EndEdit();
            };

            //来消息闪烁
            Timer timerText = new Timer();
            timerText.Interval = 300;
            timerText.Tick += delegate
            {
                this.drawText = !this.drawText;
                this.Invalidate(new Rectangle(18, 0, this.Width - 18, 21));
            };

            //用户组处理
            this.Users.UserCountChanged += delegate
            {
                this.Invalidate(new Rectangle(18, 0, this.Width - 18, 21));
            };
            this.Users.UserAdded += delegate(User user)
            {
                this.Controls.Add(user);

                user.Messages.CountChanged += delegate
                {
                    if (user.Messages.Count > 0)
                    {
                        timerText.Enabled = true;
                    }
                    else
                    {
                        timerText.Enabled = false;
                        this.drawText = true;
                        this.Invalidate(new Rectangle(18, 0, this.Width - 18, 21));
                    }

                    if (this.UserCalling != null)
                        this.UserCalling(user);
                };

                if (this.expanded)
                    this.resetLocation();
            };
            this.Users.UserRemoved += delegate(User user)
            {
                user.Messages.Clear();//把这个好友的消息清掉，这样SlidingBar不会画头像。比如有人发消息来，这时不查看消息，而把这个人删了，那么SildingBar就不应该再画这个人的头像了
                this.onlineList.Remove(user);
                this.offlineList.Remove(user);

                this.Controls.Remove(user);

                user.OnlineStateChanged -= User_OnlineStateChanged;//删好友时，状态事件脱链。

                this.resetLocation();
            };

        }

        public void Initialize()
        { 
            if (usersDic != null)
            {
                foreach (KeyValuePair<string,User> data in usersDic)
                {
                    this.Users.Add(data.Value);
                }
            }

         


        }

        //样式控制
        public new bool AutoScroll { get { return false; } }
        public new AnchorStyles Anchor { get { return AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right; } }
        public new Color BackColor { get { return Color.White; } }

        string groupID;
        string groupName;
        public Users Users { get; set; }

        #region 重命名
        TextBox textbox;
        public void BeginEdit()
        {
            this.textbox.Visible = true;
            this.textbox.Text = this.groupName;
            this.textbox.Focus();
            this.textbox.SelectAll();
        }

        public void EndEdit()
        {
            if (this.textbox.Text.Trim().Length == 0)
                return;
                        
            this.groupName = this.textbox.Text.Trim();
            this.textbox.Visible = false;
            this.Invalidate(new Rectangle(18, 0, this.Width - 18, 21));
        }
        #endregion

        //当前在线和不在线的列表
        List<User> onlineList;
        List<User> offlineList;

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (e.Control.Equals(this.textbox))
                return;

            User user = e.Control as User;

            user.SetBounds(0, 21 + (this.Controls.Count - 2) * 34, this.Width, 34);


            bool isOffline = user.State == OnlineState.Offline || user.State == OnlineState.Hide;
            bool hasAdded = false;
            for (int i = 0; i < (isOffline ? this.offlineList.Count : this.onlineList.Count); i++)
                if (string.CompareOrdinal(isOffline ? this.offlineList[i].UserName : this.onlineList[i].UserName, user.UserName) > 0)
                {
                    if (isOffline)
                        this.offlineList.Insert(i, user);
                    else
                        this.onlineList.Insert(i, user);

                    hasAdded = true;
                    break;
                }
            if (!hasAdded)
            {
                if (isOffline)
                    this.offlineList.Add(user);
                else
                    this.onlineList.Add(user);
            }

            user.OnlineStateChanged += new User.OnlineStateChangedHandler(User_OnlineStateChanged);
        }

        #region 在线状态改变，重新排序
        void User_OnlineStateChanged(User sender, OnlineState oldState, OnlineState newState)
        {
            if ((oldState == OnlineState.Offline || oldState == OnlineState.Hide)
                &&
                (newState == OnlineState.Away || newState == OnlineState.Busy || newState == OnlineState.Online || newState == OnlineState.Quiet)
               )
            {
                User user = this.offlineList.Find(uc => uc.UserID.Trim().ToLower() == sender.UserID.Trim().ToLower());
                this.offlineList.Remove(user);

                bool hasAdded = false;
                for (int i = 0; i < this.onlineList.Count; i++)
                    if (string.CompareOrdinal(this.onlineList[i].UserName, sender.Name) > 0)
                    {
                        this.onlineList.Insert(i, user);
                        hasAdded = true;
                        break;
                    }
                if (!hasAdded)
                    this.onlineList.Add(user);

                this.resetLocation();//排序

                this.Invalidate(new Rectangle(18, 0, this.Width - 18, 21));//刷新显示人数
            }
            else if ((oldState == OnlineState.Away || oldState == OnlineState.Busy || oldState == OnlineState.Online || oldState == OnlineState.Quiet)
                      &&
                      (newState == OnlineState.Hide || newState == OnlineState.Offline)
                    )
            {
                User user = this.onlineList.Find(u => u.UserID.Trim().ToLower() == sender.UserID.Trim().ToLower());
                this.onlineList.Remove(user);

                bool hasAdded = false;
                for (int i = 0; i < this.offlineList.Count; i++)
                    if (string.CompareOrdinal(this.offlineList[i].UserName, sender.Name) > 0)
                    {
                        this.offlineList.Insert(i, user);
                        hasAdded = true;
                        break;
                    }
                if (!hasAdded)
                    this.offlineList.Add(user);

                this.resetLocation();//排序

                this.Invalidate(new Rectangle(18, 0, this.Width - 18, 21));//刷新显示人数
            }
        }
        #endregion

        //排序后显示位置
        void resetLocation()
        {
            int top = 21;

            for (int i = 0; i < this.onlineList.Count; i++, top += 34)
                this.onlineList[i].Top = top;

            if (!Common.ShowOnlineOnly)
            {
                for (int i = 0; i < this.offlineList.Count; i++, top += 34)
                    this.offlineList[i].Top = top;
            }

            this.Height = this.expanded ? top : 21;
        }

        bool expanded = false;
        public bool Expanded
        {
            get { return this.expanded; }
            set
            {
                if (this.expanded != value)
                {
                    this.expanded = value;
                    this.Invalidate(new Rectangle(0, 0, 21, 21));

                    this.resetLocation();
                }
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            this.Focus();

            if (e.Y <= 21 && e.Button == MouseButtons.Left)
                this.Expanded = !this.Expanded;
        }

        #region 绘制
        Color fontColor = Color.FromArgb(50, 50, 50);
        bool drawText = true;//来消息时闪烁
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.DrawImage((this.expanded ? Properties.Resources.GroupExpand : Properties.Resources.GroupCollapse), 3, 3, 16, 16);

            if (this.drawText)
                e.Graphics.DrawString(this.groupName + "(" + this.onlineList.Count + "/" + this.Users.Count + ")", this.Font, new Pen(fontColor).Brush, 22, 5);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Y < 21 && this.fontColor != Color.SteelBlue)
            {
                this.fontColor = Color.SteelBlue;
                this.Invalidate(new Rectangle(22, 0, this.Width - 22, 21));
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.fontColor = Color.FromArgb(50, 50, 50);
            this.Invalidate(new Rectangle(22, 0, this.Width - 22, 21));
        }
        #endregion

        //响应User.Message变化事件，并通知SlidingBar控件画用户头像
        public delegate void UserCallingHandler(User user);
        public event UserCallingHandler UserCalling;




        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            drgevent.Effect = DragDropEffects.Move;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            User user = drgevent.Data.GetData(typeof(User)) as User;
            if (user == null)
                return;

            if (user.Group != this)
            {
                user.Group.Users.Remove(user);
                this.Users.Add(user);

                Common.ToDragDropUser(user, this);
            }
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            if (this.Parent != null)
            {
                for (int i = 0; i < this.Parent.Controls.Count; i++)
                {
                    Group group = this.Parent.Controls[i] as Group;
                    if (group == null)
                        continue;

                    group.Expanded = false;
                }
            }
        }
    }

    public class Users : List<User>
    {
        Group group;
        public Users(Group Group)
        {
            this.group = Group;
        }

        public new void Add(User User)
        {
            User.Group = this.group;
            base.Add(User);

            if (this.UserAdded != null)
                this.UserAdded(User);

            if (this.UserCountChanged != null)
                this.UserCountChanged(this, null);
        }

        public new void Remove(User User)
        {
            base.Remove(User);

            if (this.UserRemoved != null)
                this.UserRemoved(User);

            if (this.UserCountChanged != null)
                this.UserCountChanged(this, null);
        }

        public void RemoveByID(string UserID)
        {
            User user = base.Find(u => u.UserID.Trim().ToLower() == UserID.Trim().ToLower());
            if (user != null)
                this.Remove(user);
        }

        public new bool Contains(User User)
        {
            return base.Contains(User);
        }

        public bool Contains(string UserID)
        {
            User user = base.Find(u => u.UserID.Trim().ToLower() == UserID.Trim().ToLower());
            return user == null ? false : true;
        }

        public User GetUser(string UserID)
        {
            User user = base.Find(u => u.UserID.Trim().ToLower() == UserID.Trim().ToLower());
            return user;
        }

        public event EventHandler UserCountChanged;

        public delegate void UserInOutHandler(User user);
        public event UserInOutHandler UserAdded;
        public event UserInOutHandler UserRemoved;
    }
}
