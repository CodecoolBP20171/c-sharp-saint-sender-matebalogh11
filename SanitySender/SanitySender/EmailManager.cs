using System.Collections.Generic;
using S22.Imap;
using System.Net.Mail;
using System.Windows.Forms;

namespace SaintSender
{
    public class EmailManager
    {
        static EmailManager eManager;
        ConnectionManager cManager;
        public MainForm form;

        private EmailManager() { }

        public static EmailManager GetInstance()
        {
            if (eManager == null) eManager = new EmailManager();
            return eManager;
        }

        public void LoadEmails(ListView list)
        {
            list.Items.Clear();
            cManager = ConnectionManager.GetInstance();
            IEnumerable<uint> uids = cManager.Client.Search(SearchCondition.All());
            IEnumerable<MailMessage> messages = cManager.Client.GetMessages(uids);
            foreach(MailMessage message in messages)
            {
                ListViewItem item = new ListViewItem(new string[] { message.From.ToString(), message.Subject });
                item.Tag = message;
                list.Items.Add(item);
            }
        }

        public void OnMessage(object sender, IdleMessageEventArgs e)
        {
            MailMessage m = e.Client.GetMessage(e.MessageUID);
            form.Invoke(form.myDelegate, new object[] { m, false });
        }

        public void OnDeletion(object sender, IdleMessageEventArgs e)
        {
            MailMessage m = e.Client.GetMessage(e.MessageUID);
            form.Invoke(form.myDelegate, new object[] { m, true });
        }
    }
}
