using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NetworkCommsDotNet;

namespace WIMClient
{
    public partial class P2PUserForm : Form
    {
        public P2PUserForm()
        {
            InitializeComponent();

            ShowP2PUserList();
        }

        private void ShowP2PUserList()
        {
            

            foreach (KeyValuePair<string, Connection> keyValue in Common.UserConnList)
            {

                listBox1.Items.Add(keyValue.Key);
            }
        }
    }
}
