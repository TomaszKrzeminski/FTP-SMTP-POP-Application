using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MailOperations.Models
{
    public class DownloadFileFromFTP
    {   


       public Dictionary<string,bool> ListOfFiles { get; set; }

        public DownloadFileFromFTP()
        {
            ListOfFiles =new Dictionary<string, bool>();
        }





        public List<string> GetListOfFiles(string Login,string Password,string RequestUriString)
        {


            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(RequestUriString);
                ftpRequest.Credentials = new NetworkCredential("Tomek", "Sekret123@");
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                List<string> directories = new List<string>();

                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    directories.Add(line);
                    line = streamReader.ReadLine();
                }
                streamReader.Close();
                return directories;
            }
            catch(Exception ex)
            {
                return new List<string>();
            }
          




        }




        public bool DownloadFile(string FileNameAndType,string Login,string Password, string RequestUriString)
        {
            try
            {

                 FtpWebRequest request =
                (FtpWebRequest)WebRequest.Create(RequestUriString+FileNameAndType);
                request.Credentials = new NetworkCredential(Login, Password);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                using (Stream ftpStream = request.GetResponse().GetResponseStream())              
                using (Stream fileStream = File.Create(path + @"\"+FileNameAndType))
                {
                    ftpStream.CopyTo(fileStream);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

    }
}
