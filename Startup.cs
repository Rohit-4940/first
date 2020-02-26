using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HimalayanOrganicFarm.Models;
using HimalayanOrganicFarm.Repository.Implementation;
using HimalayanOrganicFarm.Repository.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HialayanOrganicFarm
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<Database>(data => data.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
        
            services.AddScoped<IDepartment, SqlDepartmentrepository>();
            services.AddScoped<Idesignation, SqlDesignationrepository>();
            services.AddScoped<IEmployee, SqlEmployeerepository>();
            services.AddScoped<Ileave, SqlLeaverepository>();
            services.AddScoped<ISalary, SqlSalaryrepository>();
            services.AddScoped<IVacancy, SqlVacancyrepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStaticFiles();
                app.UseDeveloperExceptionPage();
                //app.UseMvcWithDefaultRoute();
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                "default",
                "{controller=Home}/{action=dashboard}/{id?}");//default design page will load in browser 
            });

        }
    }
}
