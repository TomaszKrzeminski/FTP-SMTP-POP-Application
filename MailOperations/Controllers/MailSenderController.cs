using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailOperations.Models;
using Microsoft.AspNetCore.Mvc;

namespace MailOperations.Controllers
{
    public class MailSenderController : Controller
    {

        private IRepository repository;

        public MailSenderController(IRepository repo)
        {
            this.repository = repo;
        }


        public ViewResult HomePage()
        {
            return View();
        }


        public ViewResult Settings()
        {
            SettingsData data = repository.GetSettings();

            return View(data);
        }

        [HttpPost]
        public ViewResult Settings(SettingsData data)
        {
            return View();
        }

        public ViewResult SendEmail()
        {
            MailSender newMail = new MailSender() { Receiver = "tomaszkrzeminski21081985@gmail.com", MessageTitle = "Mail title", MessageText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." };
            return View(newMail);
        }

        [HttpPost]
        public ViewResult SendEmail(MailSender newMail)
        {
            SettingsData data = repository.GetSettings();

            if (ModelState.IsValid)
            {
              bool check=newMail.SendMail(data.SMTP_Host,data.SMTP_EmailAddress,newMail.Receiver,newMail.MessageTitle,newMail.MessageText,data.SMTP_Login,data.SMTP_Password,data.SMTP_EnableSsl,data.SMTP_Port);

                if(check)
                {
                    return View("Message", "Message Send");
                }
                else
                {
                    return View("Message", "Message Send Error");
                }
                
            }
            else
            {
                return View(newMail);
            }




           
        }


    }
}