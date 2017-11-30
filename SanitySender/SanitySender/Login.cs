using System;
using System.Windows.Forms;

namespace SaintSender
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            BackupManager mngr = new BackupManager();
            string[] creds = mngr.RestoreUserData();
            txtPass.PasswordChar = '*';
            txtName.Text = creds[0];
            txtPass.Text = creds[1];
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int d = await ConnectionManager.GetInstance().Login(txtName.Text, txtPass.Text);
            if (d != 0)
            {
                BackupManager mngr = new BackupManager(txtName.Text, txtPass.Text);
                this.Close();
            }
            else { Cursor = Cursors.Arrow; }
        }
    }
}
