using S22.Imap;
using System.Windows.Forms;

namespace SaintSender
{
    public class ConnectionManager
    {
        static ConnectionManager manager;
        ImapClient client;
        bool connected = false;

        public ImapClient Client { get => client;
            set
            {
                if(client == default(ImapClient))
                {
                    client = value;
                }
            }
        }

        private ConnectionManager() { }

        public static ConnectionManager GetInstance()
        {
            if (manager == null) manager = new ConnectionManager();
            return manager;
        }

        public  bool Login(string usrn, string pw)
        {
            Client = new ImapClient("imap.gmail.com", 993, true);
            try
            {
                Client.Login(usrn, pw, AuthMethod.Login);
                connected = true;
                return true;
            }
            catch(InvalidCredentialsException)
            {
                MessageBox.Show("The server rejected the supplied credentials.");
            }
            return false;
        }

        public void KillConnection()
        {
            if (Client != null) Client.Dispose();
        }
    }
}