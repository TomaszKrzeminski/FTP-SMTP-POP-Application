using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MailOperations.Models
{
    public class SettingsData
    {



        public SettingsData Copy()
        {
             SettingsData data=  (SettingsData)this.MemberwiseClone();
            data.SettingsDataId = 0;
            return data;
        }



        public int SettingsDataId { get; set; }
        [Required]
        public string SMTP_Login { get; set; }
        [Required]
        public string SMTP_Password { get; set; }
        [Required]
        public string SMTP_Host { get; set; }
        [Required]
        public string SMTP_EmailAddress { get; set; }
        [Required]
        public int SMTP_Port { get; set; }
        [Required]
        public bool SMTP_EnableSsl { get; set; }


        [Required]
        public string Pop3_Login { get; set; }
        [Required]
        public string Pop3_Password { get; set; }
        [Required]
        public string Pop3_Host { get; set; }
       
        [Required]
        public int Pop3_Port { get; set; }
        [Required]
        public bool Pop3_EnableSsl { get; set; }


        [Required]
        public string RequestUriString { get; set; }
        [Required]
        public string FTP_Login { get; set; }
        [Required]
        public string FTP_Password { get; set; }
        [Required]
        public string FTP_Path { get; set; }



    }
}
