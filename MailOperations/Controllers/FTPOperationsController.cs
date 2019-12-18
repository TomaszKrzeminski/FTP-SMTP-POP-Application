using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MailOperations.Controllers
{
    public class FTPOperationsController : Controller
    {
       public ViewResult UploadFile()
        {
            return View();
        }



        public ViewResult DownloadFile()
        {
            return View();
        }


    }
}