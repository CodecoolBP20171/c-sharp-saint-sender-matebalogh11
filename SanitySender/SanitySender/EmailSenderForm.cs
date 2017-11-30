using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaintSender
{
    public partial class EmailSenderForm : Form
    {
        MainForm mainForm;
        public EmailSenderForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> emailData = new Dictionary<string, string>();
            EmailManager eManager = EmailManager.GetInstance();
            if (textBoxTo.Text != null && textBoxBody.Text != null && textBoxSubject.Text != null)
            {
                emailData.Add("subject", textBoxSubject.Text);
                emailData.Add("body", textBoxBody.Text);
                emailData.Add("to", textBoxTo.Text);
                Cursor = Cursors.WaitCursor;
                int b = await eManager.SendEmal(emailData);

                mainForm.Enabled = true;
                this.Close();
            } else
            {
                MessageBox.Show("You have to fill all the fields!");
            }
        }
    }
}
