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

        public async Task<int> Login(string usrn, string pw)
        {
            Client = new ImapClient("imap.gmail.com", 993, true);
                return await Task.Run(() =>
                {
                    try
                    {
                        Client.Login(usrn, pw, AuthMethod.Auto);
                        SetUpListeners();
                        return 1;
                    } catch (InvalidCredentialsException)
                    {
                        MessageBox.Show("Invalid credentials", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    return 0;
                });
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