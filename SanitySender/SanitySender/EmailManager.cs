using System.Collections.Generic;
using S22.Imap;
using System.Net.Mail;

namespace SaintSender
{
    public class EmailManager
    {
        public static void LoadEmails()
        {
            IEnumerable<uint> uids = ConnectionManager.Client.Search(SearchCondition.All());
            IEnumerable<MailMessage> messages = ConnectionManager.Client.GetMessages(uids);
        }

    }
}
