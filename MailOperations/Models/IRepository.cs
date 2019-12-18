using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOperations.Models
{
    public interface IRepository
    {
        void AddSettingsData(SettingsData data);
        SettingsData GetSettings();

    }


    public class Repository:IRepository
    {

     private   ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {

            this.context = context;

        }


        public void AddSettingsData(SettingsData data)
        {

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
    }



}
