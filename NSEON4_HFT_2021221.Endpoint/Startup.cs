using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSEON4_HFT_2021221.Data;
using NSEON4_HFT_2021221.Logic;
using NSEON4_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IPhoneLogic, PhoneLogic>();
            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IHeadquarterLogic, HeadquarterLogic>();
            services.AddTransient<ICountryLogic, CountryLogic>();

            services.AddTransient<IPhoneRepository, PhoneRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IHeadquarterRepository, HeadquarterRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();

            services.AddTransient<PhoneDbContext, PhoneDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
