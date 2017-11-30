using System.Collections.Generic;
using S22.Imap;
using System.Net.Mail;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System;

namespace SaintSender
{
    public class EmailManager
    {
        static EmailManager eManager;
        ConnectionManager cManager;
        private MainForm form;

        public MainForm Form { get => form; set => form = value; }

        private EmailManager() { }

        public static EmailManager GetInstance()
        {
            if (eManager == null) eManager = new EmailManager();
            return eManager;
        }

        public async Task<List<ListViewItem>> LoadEmails()
        {
            return await Task.Run(() =>
            {
                bool seen = false;
                List<ListViewItem> itemList = new List<ListViewItem>();
                cManager = ConnectionManager.GetInstance();
                IEnumerable<uint> uids = cManager.Client.Search(SearchCondition.All());
                IEnumerable<MailMessage> messages = cManager.Client.GetMessages(uids);
                IEnumerator<uint> uidList = uids.GetEnumerator();
                foreach (MailMessage message in messages)
                {
                    ListViewItem item = new ListViewItem(new string[] { message.From.ToString().Trim(), message.Subject.Trim() }, 0);
                    CreateHTMLBody(message);
                    item.Tag = message.Body;

                    uidList.MoveNext();
                    IEnumerable<MessageFlag> flags = cManager.Client.GetMessageFlags(uidList.Current);
                    foreach (MessageFlag flag in flags)
                    {
                        if (flag.HasFlag(MessageFlag.Seen) == true) { seen = true; break; }
                    }
                    if (!seen) item.Font = new Font(item.Font, FontStyle.Bold);
                    itemList.Add(item);
                    seen = false;
                }
                return itemList;
            });
        }

        private void CreateHTMLBody(MailMessage message)
        {
            var dataStream = message.AlternateViews[0].ContentStream;
            byte[] byteBuffer = new byte[dataStream.Length];
            string altBody = System.Text.Encoding.UTF8.GetString(byteBuffer, 0, dataStream.Read(byteBuffer, 0, byteBuffer.Length));
            message.Body = altBody;
        }

        public async Task<IEnumerable<MailMessage>> FetchEmails()
        {
            return await Task.Run(() =>
            {
                cManager = ConnectionManager.GetInstance();
                IEnumerable<uint> uids = cManager.Client.Search(SearchCondition.All());
                return cManager.Client.GetMessages(uids);
            });
        }

        public void OnMessage(object sender, IdleMessageEventArgs e)
        {
            MailMessage m = e.Client.GetMessage(e.MessageUID);
            Form.Invoke(Form.MyDelegate, new object[] { m, false });
        }

        public void OnDeletion(object sender, IdleMessageEventArgs e)
        {
            MailMessage m = e.Client.GetMessage(e.MessageUID);
            Form.Invoke(Form.MyDelegate, new object[] { m, true });
        }

        public async Task<int> SendEmal(Dictionary<string, string> emailData)
        {
            return await Task.Run(() =>
            {
                try
                {
                    BackupManager bManager = new BackupManager();
                    string[] creds = bManager.RestoreUserData();
                    MailMessage mail = new MailMessage(creds[0], emailData["to"]);
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new System.Net.NetworkCredential(creds[0], creds[1]);
                    mail.Subject = emailData["subject"];
                    mail.Body = emailData["body"];
                    client.Send(mail);
                    return 0;
                } catch (FormatException)
                {
                    MessageBox.Show("Invalid email address.");
                }
                return 1;
            });
        }
    }
}
