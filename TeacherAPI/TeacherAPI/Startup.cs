using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TeacherAPI.Models;
using TeacherAPI.Controllers;
using TeacherAPI.Services;

namespace TeacherAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITeacherDatabaseSettings>(p => new TeacherDatabaseSettings
            {
                ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING"),
                DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME"),
                TeacherCollectionName = nameof(Teacher)

            });
            services.AddTransient<TeacherService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
