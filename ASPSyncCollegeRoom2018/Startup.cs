#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPSyncCollegeRoom2018.Data;
using ASPSyncCollegeRoom2018.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASPSyncCollegeRoom2018
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Adding In Memory Database. https://dotnetthoughts.net/getting-started-with-odata-in-aspnet-core/

            //services.AddDbContext<CalendarDBContext>(options =>
            //{
            //    options.UseInMemoryDatabase("InMemoryDb");
            //});

            services.AddDbContext<CalendarDBContext>(options =>
                options.UseSqlite("Data Source=cal.db"));

            //Adding OData middleware.
            services.AddOData();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //Adding Model class to OData
            var builder = GetEdmModel(app.ApplicationServices);
            builder.EntitySet<ScheduleData>(nameof(ScheduleData));
            builder.EntitySet<Appointment>(nameof(Appointment));


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc((routebuilder =>
            {
                routebuilder.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
                routebuilder.EnableDependencyInjection(); //hack? https://github.com/OData/WebApi/issues/1175
            }));

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        //https://stackoverflow.com/questions/48551571/creating-enbdpoints-that-return-odata-in-asp-net-core-web-api/48558352#48558352 
        private static ODataConventionModelBuilder GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            return builder;
        }

    }
}
