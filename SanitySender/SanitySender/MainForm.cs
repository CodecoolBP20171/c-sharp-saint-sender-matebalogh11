using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace SaintSender
{
    public partial class MainForm : Form
    {
        public delegate void AddListViewItem(MailMessage m, bool b);
        public AddListViewItem myDelegate;
        EmailManager eManager;
        public static ListView v;

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
            eManager = EmailManager.GetInstance();
            eManager.form = this;
            Enabled = true;
            eManager.LoadEmails(MainListView);
        }

        void MainListView_Click(object sender, EventArgs e)
        {
            var firstSelectedItem = MainListView.SelectedItems[0];
            MailMessage m = firstSelectedItem.Tag as MailMessage;
            MainBox.Text = m.Body.Trim();
        }

        public void AddListItemMethod(MailMessage m, bool b)
        {
            if (b == false)
            {
                ListViewItem item = new ListViewItem(new string[] { m.From.ToString(), m.Subject });
                item.Tag = m;
                MainListView.Items.Add(item);
            }
            else
            {
                eManager.LoadEmails(MainListView);
            }
        }
    }
}
