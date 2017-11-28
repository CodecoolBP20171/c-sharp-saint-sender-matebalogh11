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
            txtPass.PasswordChar = '*';
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (ConnectionManager.GetInstance().Login(txtName.Text, txtPass.Text))
            {
                this.Close();
            }
        }

        public void Login_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
