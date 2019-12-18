using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOperations.Models
{
    public class Seed
    {

        ApplicationDbContext context;

        public Seed(ApplicationDbContext context)
        {
            this.context = context;
        }


        public void EnsurePopulated(ApplicationDbContext context)
        {

            bool check;
            check = context.Database.EnsureCreated();



            if (check)
            {

                SettingsData data = new SettingsData();
                data.SMTP_Login = "tomekkowalskitestmail@gmail.com";
                data.SMTP_Password = "Sekret123@";
                data.SMTP_Host = "smtp.gmail.com";
                data.SMTP_EmailAddress = "tomekkowalskitestmail@gmail.com";
                data.SMTP_Port = 587;
                data.SMTP_EnableSsl = true;

                data.Pop3_Login = "tomekkowalskitestmail@gmail.com";
                data.Pop3_Password = "Sekret123@";
                data.Pop3_Host = "pop.gmail.com";               
                data.Pop3_Port = 995;
                data.Pop3_EnableSsl = true;

                data.RequestUriString = @"ftp://www.TestSiteTomekKrzeminski.somee.com/www.TestSiteTomekKrzeminski.somee.com/GetUser()2.txt";
                data.FTP_Login ="Tomek";
                data.FTP_Password = "Daria21081985@";
                data.FTP_Path = @"C:\Users\tomek\Desktop\GetUser()2.txt";

                context.Settings.Add(data);
                context.SaveChanges();


    }



        }

    }
}
