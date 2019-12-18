using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailOperations.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MailOperations
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration) => Configuration = configuration;



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext < ApplicationDbContext > (options => options.UseSqlServer(Configuration["Data:SettingsMail:ConnectionString"]));


            services.AddTransient<IRepository, Repository>();
            services.AddTransient<Seed>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ApplicationDbContext context, Seed seed)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes=> {
                routes.MapRoute(name: "default", template: "{controller=MailSender}/{action=HomePage}/{id?}");

            });


            seed.EnsurePopulated(context);


        }
    }
}
