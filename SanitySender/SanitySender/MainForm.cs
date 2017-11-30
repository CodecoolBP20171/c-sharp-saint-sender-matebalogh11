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
        private AddListViewItem myDelegate;
        EmailManager eManager;

        public AddListViewItem MyDelegate { get => myDelegate; set => myDelegate = value; }
        public EmailManager EManager { get => eManager; set => eManager = value; }

        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            MyDelegate = new AddListViewItem(AddListItemMethod);
            LoginForm lg = new LoginForm();
            lg.FormClosed += new FormClosedEventHandler(Login_FormClosed);
            lg.Show();
        }

        public void SendFormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
        }

        public async void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!ConnectionManager.GetInstance().Client.Authed)
            {
                this.Close();
            } else
            {
                Cursor = Cursors.WaitCursor;
                mainBrowser.DocumentText = "Emails are loading please wait...";
                EManager = EmailManager.GetInstance();
                EManager.Form = this;
                Enabled = true;
                List<ListViewItem> list = await EManager.LoadEmails();
                PopulateListView(list);
                EnableButtons();
                Cursor = Cursors.Arrow;
                mainBrowser.DocumentText = "";
            }
        }

        private void PopulateListView(List<ListViewItem> list)
        {
            foreach (ListViewItem item in list)
            {
                MainListView.Items.Add(item);
            }
        }

        private void EnableButtons()
        {
            buttonBackUp.Enabled = buttonClear.Enabled = buttonFetch.Enabled = buttonRestore.Enabled = true;
        }

        void MainListView_Click(object sender, EventArgs e)
        {
            ListViewItem item = MainListView.SelectedItems[0] as ListViewItem;
            item.Font = new Font(item.Font, FontStyle.Regular);
            mainBrowser.DocumentText = item.Tag as string;
        }

        public async void AddListItemMethod(MailMessage m, bool b)
        {
            if (b == false)
            {
                ListViewItem item = new ListViewItem(new string[] { m.From.ToString(), m.Subject }, 0);
                item.Tag = m.Body;
                item.Font = new Font(item.Font, FontStyle.Bold);
                MainListView.Items.Add(item);
            }
            else
            {
                MainListView.Items.Clear();
                List<ListViewItem> list = await EManager.LoadEmails();
                foreach (ListViewItem item in list)
                {
                    MainListView.Items.Add(item);
                }
            }
        }

        private async void buttonBackUp_Click(object sender, EventArgs e)
        {
            mainBrowser.DocumentText = "Backup data creation is in progress...";
            IEnumerable <MailMessage> messages = await EManager.FetchEmails();
            BackupManager bManager = new BackupManager();
            int b = await bManager.SerializeMails(messages);
            mainBrowser.DocumentText = "";
            MessageBox.Show("Backup created!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
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

        private async void buttonFetch_Click(object sender, EventArgs e)
        {
            MainListView.Items.Clear();
            List<ListViewItem> list = await EManager.LoadEmails();
            PopulateListView(list);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            EmailSenderForm eSender = new EmailSenderForm(this);
            eSender.FormClosed += SendFormClosed;
            eSender.Show();
            this.Enabled = false;
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            ConnectionManager cManager = ConnectionManager.GetInstance();
            cManager.Client.Dispose();
            this.Close();
        }
    }
}
