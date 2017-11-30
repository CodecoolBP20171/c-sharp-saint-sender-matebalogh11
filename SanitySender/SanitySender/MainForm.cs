using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;

namespace SaintSender
{
    public partial class MainForm : Form
    {
        public delegate void AddListViewItem(MailMessage m, bool b);
        public AddListViewItem myDelegate;
        EmailManager eManager;

        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            myDelegate = new AddListViewItem(AddListItemMethod);
            LoginForm lg = new LoginForm();
            lg.FormClosed += new FormClosedEventHandler(Login_FormClosed);
            lg.Show();
        }

        public void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ConnectionManager.GetInstance().Client == null)
            {
                this.Close();
            } else
            {
                eManager = EmailManager.GetInstance();
                eManager.form = this;
                Enabled = true;
                eManager.LoadEmails(MainListView);
            }
        }

        void MainListView_Click(object sender, EventArgs e)
        {
            var firstSelectedItem = MainListView.SelectedItems[0];
            ListViewItem item = firstSelectedItem as ListViewItem;
            item.Font = new Font(item.Font, FontStyle.Regular);
            MailMessage m = firstSelectedItem.Tag as MailMessage;

            var dataStream = m.AlternateViews[0].ContentStream;
            byte[] byteBuffer = new byte[dataStream.Length];
            string altBody = System.Text.Encoding.UTF8.GetString(byteBuffer, 0, dataStream.Read(byteBuffer, 0, byteBuffer.Length));
            mainBrowser.DocumentText = (altBody.Equals("")) ? m.Body : altBody;
        }

        public void AddListItemMethod(MailMessage m, bool b)
        {
            if (b == false)
            {
                ListViewItem item = new ListViewItem(new string[] { m.From.ToString(), m.Subject });
                item.Tag = m;
                item.Font = new Font(item.Font, FontStyle.Bold);
                MainListView.Items.Add(item);
            }
            else
            {
                eManager.LoadEmails(MainListView);
            }
        }

        private void buttonBackUp_Click(object sender, EventArgs e)
        {
            IEnumerable<MailMessage> messages = eManager.FetchEmails();
            BackupManager bManager = new BackupManager();
            bManager.SerializeMails(messages);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            MainListView.Items.Clear();
            
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            List<MailMessage> mails;
            BackupManager bManager = new BackupManager();
            mails = bManager.DeserializeMails();
            bManager.LoadBackUp(MainListView, mails);
        }
    }
}
