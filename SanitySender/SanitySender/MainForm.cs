using System;
using System.Windows.Forms;

namespace SaintSender
{
    public partial class MainForm : Form
    {
        EmailManager eManager;

        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();

            Login lg = new Login();
            lg.FormClosed += new FormClosedEventHandler(this.Login_FormClosed);
            lg.Show();
        }


        public void ShowEmails()
        {
            eManager = EmailManager.GetInstance();
            eManager.LoadEmails(MainListView);
        }

        public void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Enabled = true;
            ShowEmails();
        }

        void MainListView_Click(object sender, EventArgs e)
        {
            var firstSelectedItem = MainListView.SelectedItems[0];
            MainBox.Text = firstSelectedItem.Tag.ToString();
        }
    }
}
