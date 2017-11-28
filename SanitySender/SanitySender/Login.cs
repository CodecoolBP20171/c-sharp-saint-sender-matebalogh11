using System;
using System.Windows.Forms;

namespace SaintSender
{
    public partial class Login : Form
    {
        Form MainForm;
        public Login(Form Main)
        {
            InitializeComponent();
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            MainForm = Main;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (ConnectionManager.Login(txtName.Text, txtPass.Text))
            {
                MainForm.Enabled = true;
                this.Close();
            }
        }
    }
}
