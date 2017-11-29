using System.Collections.Generic;
using S22.Imap;
using System.Net.Mail;
using System.Windows.Forms;
using System.Drawing;

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
            bool seen = false;
            list.Items.Clear();
            cManager = ConnectionManager.GetInstance();
            IEnumerable<uint> uids = cManager.Client.Search(SearchCondition.All());
            IEnumerable<MailMessage> messages = cManager.Client.GetMessages(uids);
            IEnumerator<uint> uidList = uids.GetEnumerator();
            foreach (MailMessage message in messages)
            {
                ListViewItem item = new ListViewItem(new string[] { message.From.ToString().Trim(), message.Subject.Trim() }, 0);
                item.Tag = message;
                uidList.MoveNext();
                IEnumerable<MessageFlag> flags = cManager.Client.GetMessageFlags(uidList.Current);
                foreach(MessageFlag flag in flags)
                {
                    if (flag.HasFlag(MessageFlag.Seen) == true) { seen = true; break; }
                }
                if (!seen) item.Font = new Font(item.Font, FontStyle.Bold);
                list.Items.Add(item);
                seen = false;
            }
        }

        public IEnumerable<MailMessage> FetchEmails()
        {
            cManager = ConnectionManager.GetInstance();
            IEnumerable<uint> uids = cManager.Client.Search(SearchCondition.All());
            return cManager.Client.GetMessages(uids);
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
