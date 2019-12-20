using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailOperations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace MailOperations.Controllers
{
    public class MailReceiverController : Controller
    {

        private IRepository repository;

        public MailReceiverController(IRepository repository)
        {
            this.repository = repository;
        }


        

        public ViewResult GetEmails()
        {
            GetEmailsClass emails = new GetEmailsClass();
            SettingsData data = repository.GetSettings();

            List<OpenPop.Mime.Message> list = emails.GetAllMessages(data.Pop3_Host,data.Pop3_Port,data.Pop3_EnableSsl,data.Pop3_Login,data.Pop3_Password);


            return View(list);
        }

        public ViewResult ShowDetails(string id)
        {
            GetEmailsClass emails = new GetEmailsClass();
            SettingsData data = repository.GetSettings();

            List<OpenPop.Mime.Message> list = emails.GetAllMessages(data.Pop3_Host, data.Pop3_Port, data.Pop3_EnableSsl, data.Pop3_Login, data.Pop3_Password);

            OpenPop.Mime.Message message = list.Where(m => m.Headers.MessageId == id).First();

          string Text= emails.GetMessageBodyAsText(message);

            EmailViewModel model = new EmailViewModel() {Text=Text,From=message.Headers.From.Address,MessageSubject=message.Headers.Subject };
  

            return View(model);
        }




    }
}