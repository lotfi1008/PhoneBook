using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Domain.Contracts.People;
using PhoneBook.Domain.Contracts.Phones;
using PhoneBook.Domain.Contracts.Tags;
using PhoneBook.Infrastructures.DataLayer.Common;
using PhoneBook.Infrastructures.DataLayer.People;
using PhoneBook.Infrastructures.DataLayer.Phones;
using PhoneBook.Infrastructures.DataLayer.Tags;

namespace PhoneBook.EndPoints.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddDbContext<PhoneBookContext>(c => c.UseSqlServer(Configuration.GetConnectionString("nargoon")));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Exception");
            }
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
