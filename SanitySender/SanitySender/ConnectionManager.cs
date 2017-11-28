using S22.Imap;
using System;
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
                SetUpListeners();
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

        public void SetUpListeners()
        {
            if (Client != null)
            {
                if (Client.Supports("IDLE") == true)
                {
                    Client.NewMessage += new EventHandler<IdleMessageEventArgs>(EmailManager.GetInstance().OnMessage);
                    Client.MessageDeleted += new EventHandler<IdleMessageEventArgs>(EmailManager.GetInstance().OnDeletion);
                }
            }
        }
    }
}