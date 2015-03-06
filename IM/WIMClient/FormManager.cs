//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace WIMClient
{
    public class FormManager<TForm> where TForm : Form, IManagedForm
    {
        private Dictionary<string,TForm> formDictionary;
        private object locker;

       

        public event EventHandler<FormIDEventArgs> FormClosed;

        public FormManager()
        {
            this.formDictionary = new Dictionary<string, TForm>();
            this.locker = new object();
            this.FormClosed += delegate
            {
            };
        }

        public void Add(TForm form)
        {
            lock (this.locker)
            {
                if (this.formDictionary.ContainsKey(form.FormID))
                {
                    TForm local = this.formDictionary[form.FormID];
                    local.FormClosed -= new FormClosedEventHandler(this.form_FormClosed);
                    this.formDictionary.Remove(form.FormID);
                }
                form.FormClosed += new FormClosedEventHandler(this.form_FormClosed);
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
                TForm local = (TForm)sender;
                if (this.formDictionary.ContainsKey(local.FormID) && (local == this.formDictionary[local.FormID]))
                {
                    this.formDictionary.Remove(local.FormID);
                   
                    this.FormClosed.Raise(this, new FormIDEventArgs(local.FormID));
                }
            }
        }

        public List<TForm> GetAllForms()
        {
            lock (this.locker)
            {
                return new List<TForm>(this.formDictionary.Values);
            }
        }

        public TForm GetForm(string id)
        {
            if (this.formDictionary.ContainsKey(id))
            {
                return this.formDictionary[id];
            }
            return default(TForm);
        }
    }

    public interface IManagedForm 
    {
        String FormID { get; }
    }
}
