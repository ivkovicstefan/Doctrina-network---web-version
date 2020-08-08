using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctrina___Web.Hubs;
using Doctrina___Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Doctrina___Web
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddDbContextPool<DoctrinaDBContext>(
                options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(_config.GetConnectionString("AzureServer")));
            services.AddIdentity<DoctrinaUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
            }).AddEntityFrameworkStores<DoctrinaDBContext>();
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
            }).AddRazorRuntimeCompilation();
            services.AddScoped<IDoctrinaUserRepository, DoctrinaUserRepository>();
            services.AddScoped<IDoctrinaGroupRepository, DoctrinaGroupRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapHub<NotificationHub>("/notificationHub");
            });
        }
    }
}
