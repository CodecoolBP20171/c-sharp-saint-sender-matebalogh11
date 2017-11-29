using S22.Imap;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaintSender
{
    public class ConnectionManager
    {
        static ConnectionManager manager;
        ImapClient client;

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

        public async Task Login(string usrn, string pw)
        {
            Client = new ImapClient("imap.gmail.com", 993, true);
            try
            {
                await Task.Run(() => Client.Login(usrn, pw, AuthMethod.Login));
                SetUpListeners();
            }
            catch(InvalidCredentialsException)
            {
                MessageBox.Show("The server rejected the supplied credentials.");
            }
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