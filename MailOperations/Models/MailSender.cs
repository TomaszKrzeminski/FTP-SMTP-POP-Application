using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MailOperations.Models
{
    public class MailSender
    {
        [Required]
        public string Receiver { get; set; }
        [Required]
        public string MessageTitle { get; set; }
        [Required]
        public string MessageText { get; set; }



        public bool SendMail(string Host,string From,string Receiver,string Title,string Text,string Login,string Password,bool Ssl,int PortNumber)
        {

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient server = new SmtpClient(Host);
                mail.From = new MailAddress(From);
                mail.To.Add(Receiver);
                mail.Subject = Title;
                mail.Body = Text;

                server.Port = PortNumber;
                server.Credentials = new System.Net.NetworkCredential(Login, Password);
                server.EnableSsl = Ssl;

                server.Send(mail);
                return true;

            }
            catch(Exception ex)
            {
                return false;

            }

                                


        }




    }
}
