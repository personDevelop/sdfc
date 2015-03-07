﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMInterface;

namespace ChatClient
{
    public class FormManager
    {
        private object locker=new object();
        public static readonly FormManager Instance;
        public static frmMain MainForm;
        public event EventHandler<FormIDEventArgs> FormClosed;
        static FormManager()
        {
            Instance = new FormManager();
        }
        private FormManager() { }
        private Dictionary<string, IManagedForm> formDictionary=new Dictionary<string,IManagedForm>();
        public void Add(IManagedForm form)
        {
            lock (this.locker)
            {

                if (this.formDictionary.ContainsKey(form.FormID))
                {
                    IManagedForm local = this.formDictionary[form.FormID];
                    local.CurrentForm.FormClosed -= new FormClosedEventHandler(this.form_FormClosed);
                    this.formDictionary.Remove(form.FormID);
                }
                form.CurrentForm.FormClosed += new FormClosedEventHandler(this.form_FormClosed);
                this.formDictionary.Add(form.FormID, form);
            }
        }

        public bool Contains(string id)
        {
            return this.formDictionary.ContainsKey(id);
        }

        private void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            lock (this.locker)
            {
                IManagedForm local = (IManagedForm)sender;
                if (this.formDictionary.ContainsKey(local.FormID) && (local == this.formDictionary[local.FormID]))
                {
                    this.formDictionary.Remove(local.FormID);

                    this.FormClosed.Raise(this, new FormIDEventArgs(local.FormID));
                }
            }
        }

        public List<IManagedForm> GetAllForms()
        {
            lock (this.locker)
            {
                return new List<IManagedForm>(this.formDictionary.Values);
            }
        }

        public IManagedForm GetForm(string id)
        {
            if (this.formDictionary.ContainsKey(id))
            {
                return this.formDictionary[id];
            }
            return null;
        }

        internal void ActivateOrCreateFormSend(IMUserInfo chatuser)
        {
            lock (locker)
            {
                IManagedForm form = GetForm(chatuser.ID);

                if (form == null)
                {
                    frmchatMain f = new frmchatMain(chatuser);
                    form = f;
                    Add(f);
                    f.Show();

                }
                (form as frmchatMain).Activate();
                if (Common.ContainsUserID(chatuser.ID))
                {
                    (form as frmchatMain).ShowOtherTextChat(chatuser.ID, Common.MsgContractList(chatuser.ID));
                    Common.RemoveID(chatuser.ID);
                    Common.RemoveMsg(chatuser.ID);
                    //this.Messages.Clear();
                }

            }
        }
    }


    public interface IManagedForm
    {
        String FormID { get; }

        Form CurrentForm { get; set; }

    }
    public class FormIDEventArgs : EventArgs
    {
        public FormIDEventArgs(string text)
        {
            Text = text;
        }
        public string Text { get; set; }

    }
}