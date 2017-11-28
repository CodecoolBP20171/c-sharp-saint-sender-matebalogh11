using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Forms;

namespace SaintSender
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            Login lg = new Login(this);
            lg.Show();
        }

        private void MainListView_Click(object sender, EventArgs e)
        {
            var firstSelectedItem = MainListView.SelectedItems[0];
            MainBox.Text = firstSelectedItem.Tag.ToString();
        }
    }
}
