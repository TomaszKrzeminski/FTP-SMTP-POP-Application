using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailOperations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;

namespace MailOperations.Controllers
{
    public class FTPOperationsController : Controller
    {

        private IRepository repository;

        public FTPOperationsController(IRepository repo)
        {
            this.repository = repo;
        }


        public ViewResult UploadFile()
        {
            UploadFileToFTP file = new UploadFileToFTP() { FilePath = @"C:\Users\tomek\Desktop\User.jpg" };
            return View(file);
        }

        [HttpPost]
        public ViewResult UploadFile(UploadFileToFTP file)
        {

            SettingsData data = repository.GetSettings();

            if (!String.IsNullOrEmpty(file.FilePath))
            {
                file.GetFileName();
            }


            if (ModelState.IsValid)
            {
                bool check = file.UploadFile(data.FTP_Login, data.FTP_Password, data.RequestUriString);

                if (check)
                {
                    return View("Message", "File Uploaded");
                }
                else
                {
                    return View("Message", "File Upload Error");
                }

            }
            else
            {
                return View();
            }

        }



        public ViewResult DownloadFile()
        {
            SettingsData data = repository.GetSettings();
            DownloadFileFromFTP download = new DownloadFileFromFTP();
            List<string> list = download.GetListOfFiles(data.FTP_Login, data.FTP_Password, data.RequestUriString);

            return View(list);
        }

        [HttpPost]
        public ViewResult DownloadFile(List<FileDownloadViewModel> list)
        {
            bool check = true;
            if (list != null && list.Count() > 0)
            {
                DownloadFileFromFTP download = new DownloadFileFromFTP();
                SettingsData data = repository.GetSettings();

                foreach (var file in list)
                {

                    if (file.Download == "Download")
                    {
                        bool succes = download.DownloadFile(file.FileName, data.FTP_Login, data.FTP_Password, data.RequestUriString);
                        if(succes==false)
                        {
                            check = succes;
                        }
                    }

                }

            }

            if (check)
            {
                return View("Message", "File Download Succes");
            }
            else
            {
           return View("Message","File Download Error");
            }

           
        }




    }
}