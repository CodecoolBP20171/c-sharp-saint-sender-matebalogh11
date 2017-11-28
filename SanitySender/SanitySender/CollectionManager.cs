using S22.Imap;
using System.Windows.Forms;

namespace SaintSender
{
    public class ConnectionManager
    {
        static ImapClient client;
        public static ImapClient Client { get => client;
            set
            {
                if(client == default(ImapClient))
                {
                    client = value;
                }
            }
        }

        public static bool Login(string usrn, string pw)
        {
            Client = new ImapClient("imap.gmail.com", 993, true);
            try
            {
                Client.Login(usrn, pw, AuthMethod.Login);
                return true;
            }
            catch(InvalidCredentialsException)
            {
                MessageBox.Show("The server rejected the supplied credentials.");
            }
            return false;
        }
    }
}