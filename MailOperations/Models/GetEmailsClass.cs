using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenPop.Mime;
using OpenPop.Pop3;

namespace MailOperations.Models
{
    public class GetEmailsClass
    {




        public  List<OpenPop.Mime.Message> GetAllMessages(string hostname, int port, bool ssl, string username, string password)
        {
            try
            {
                Pop3Client client = new Pop3Client();

                if (client.Connected)
                {
                    client.Disconnect();
                }

                client.Connect(hostname, port, ssl);
                client.Authenticate(username, password);

                int messageCount = client.GetMessageCount();

                List<OpenPop.Mime.Message> allMessages = new List<OpenPop.Mime.Message>(messageCount);

                for (int i = messageCount; i > messageCount - 5; i--)
                {
                    allMessages.Add(client.GetMessage(i));
                }

                return allMessages;
            }

            catch (Exception ex)
            {

            }

            return null;
        }


        public string GetMessageBodyAsText(Message message)
        {
            try
            {
                List<MessagePart> list = message.FindAllTextVersions();

                // First let's try getting the plain text part:
                foreach (MessagePart part in list)
                {
                    if (part != null)
                    {
                        return part.GetBodyAsText();
                    }
                }

                // Now let's try getting the HTML part
                MessagePart html = message.FindFirstHtmlVersion();
                if (html != null)
                {
                    return html.GetBodyAsText();
                }
                return null;
            }
            catch (Exception exc)
            {
                // Handle your exception here
                return null;
            }
        }






    }
}
