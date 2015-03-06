using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AuthorityEntity; 
namespace WIMClient.Skin
{
    public partial class RegisterUser : BasicForm
    {
        public RegisterUser()
        {
            InitializeComponent();
        }
         

       

        private void loginButton1_Click(object sender, EventArgs e)
        {
            if (txtPsw.Text.Trim() != txtRePsw.Text.Trim())
            {
                BasicMsgBoxForm form = new BasicMsgBoxForm("密码和验证密码不一致", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form.StartPosition = FormStartPosition.CenterScreen;
                  form.ShowDialog();
            }

            if (txtUserID.Text.Trim() == "" || txtPsw.Text.Trim() == ""|| txtNickName.Text.Trim()=="")
            {

                BasicMsgBoxForm form = new BasicMsgBoxForm("用户ID,用户昵称，和密码不能为空", "提示窗口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form.StartPosition = FormStartPosition.CenterScreen;
                  form.ShowDialog();
            }

            //定义一个契约类
            UserInfo currentUser = new UserInfo();
            //给属性赋值
            //currentUser.UserID = txtUserID.Text.Trim();
            //currentUser.Password = txtPsw.Text.Trim();
            //currentUser.Name = txtNickName.Text.Trim();

            ////同步方法  传递并序列化契约类到服务器，并从获取获取返回的信息  （返回的信息类型为ResMessage)
            ////RegUser 发送的消息类型
            ////ResRegUser  接收返回的消息类型
            //ResMessage regContract = Common.TcpConn.SendReceiveObject<ResMessage>("RegUser", "ResRegUser", 8000, currentUser);

            //if (regContract.Message == "注册成功")
            //{
            //    BasicMsgBoxForm form = new BasicMsgBoxForm("注册成功", "信息窗口", MessageBoxButtons.OK, MessageBoxIcon.None);
            //    form.StartPosition = FormStartPosition.CenterScreen;
            //    form.ShowDialog();

            //    txtNickName.Text = "";
            //    txtUserID.Text = "";
            //    txtPsw.Text = "";
            //    txtRePsw.Text = "";
                 
            //}
            //else
            //{
            //    BasicMsgBoxForm form = new BasicMsgBoxForm(regContract.Message, "信息窗口", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    form.StartPosition = FormStartPosition.CenterScreen;
            //    form.ShowDialog();
            //}


        }

       
     
    }
}
