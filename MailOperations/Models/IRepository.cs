using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOperations.Models
{
    public interface IRepository
    {
        bool AddSettingsData(SettingsData data);
        SettingsData GetSettings();
        bool ResetSettings();

    }


    public class Repository:IRepository
    {

     private   ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {

            this.context = context;

        }


        public bool AddSettingsData(SettingsData data)
        {

            try
            {
                context.Settings.Add(data);
                context.SaveChanges();

                return true;

            }
            catch(Exception ex)
            {
                return false;
            }


        }

        public SettingsData GetSettings()
        {
            try
            {

                SettingsData data = context.Settings.Last();
                return data;



            }
            catch(Exception ex)
            {
                return new SettingsData();
            }


        }

        public bool ResetSettings()
        {
            try
            {
                SettingsData settings=context.Settings.Find(1);
                SettingsData data = new SettingsData();
                data = settings.Copy();
                context.Settings.Add(data);
                context.SaveChanges();


                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }



}
