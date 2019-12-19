using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MailOperations.Models
{
    public class UploadFileToFTP
    {

        [Required]
        public string FilePath { get; set; }
      
        public string FileName { get; set; }


        public void GetFileName()
        {

            if(!String.IsNullOrEmpty(FilePath))
            {
                FileName = Path.GetFileName(FilePath);
            }

        }



        public bool UploadFile(string Login, string Password, string RequestUriString)
        {


            try
            {
                using (var client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(Login, Password);
                    client.UploadFile(RequestUriString + FileName, WebRequestMethods.Ftp.UploadFile, FilePath);
                    return true;
                }
            }
            catch (WebException e)
            {
                return false;
            }




        }


    }
}
