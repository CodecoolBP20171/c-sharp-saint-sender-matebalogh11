using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using S22.Mail;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace SaintSender
{
    public class BackupManager
    {

        public BackupManager(string name, string pass)
        {
            SaveUserData(name, pass);
        }

        public void SerializeMails(IEnumerable<MailMessage> emails)
        {

            BinaryFormatter formatter = new BinaryFormatter();
            int counter = 0;
            foreach(MailMessage message in emails)
            {
                using(FileStream stream = new FileStream($"backupMail{counter}.dat", FileMode.Create))
                {
                    formatter.Serialize(stream, (SerializableMailMessage)message);
                }
                counter++;
            }
        }

        public BackupManager() { }

        private void SaveUserData(string name, string pass)
        {
            using (IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly())
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("UserSettings.dat", System.IO.FileMode.Create, userStore))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine(name);
                writer.WriteLine(pass);
            }
        }

        public string[] RestoreUserData()
        {
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
            string[] files = userStore.GetFileNames();
            string[] credentials = new string[2];
            if (files.Contains<string>("UserSettings.dat"))
            {
                int count = 0;
                using (IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.dat", FileMode.Open, userStore))
                using (StreamReader userReader = new StreamReader(userStream))
                {
                    while (userReader.Peek() >= 0)
                    {
                        credentials[count] = userReader.ReadLine();
                        count++;
                    }
                }
            }
            return credentials;
        }
    }
}
