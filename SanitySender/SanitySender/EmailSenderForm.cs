using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SaintSender
{
    public partial class EmailSenderForm : Form
    {
        MainForm mainForm;
        public EmailSenderForm(MainForm mainForm)
        {
            InitializeComponent();
            this.MainForm = mainForm;
        }

        public MainForm MainForm { get => mainForm; set => mainForm = value; }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> emailData = new Dictionary<string, string>();
            EmailManager eManager = EmailManager.GetInstance();
            if (textBoxTo.Text != "" && textBoxSubject.Text != "")
            {
                emailData.Add("subject", textBoxSubject.Text);
                emailData.Add("body", textBoxBody.Text);
                emailData.Add("to", textBoxTo.Text);
                Cursor = Cursors.WaitCursor;
                int b = await eManager.SendEmal(emailData);
                if (b == 0)
                {
                    MainForm.Enabled = true;
                    this.Close();
                }
            } else
            {
                MessageBox.Show("You have to fill all the fields!");
            }
        }
    }
}
