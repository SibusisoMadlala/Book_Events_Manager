using AutoMapper;
using BookWeb.Controllers;
using BookWeb.Data;
using BookWeb.Mapper;
using Company.Project.Core.ExceptionManagement;
using Company.Project.EventDomain.AppServices;
using Company.Project.EventDomain.AppServices.Mapper;
using Company.Project.EventDomain.Data.DBContext;
using Company.Project.EventDomain.Repository;
using Company.Project.EventDomain.UoW;
//using Company.Project.ProductDomain.AppServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace BookWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //builder.Services.AddScoped<IMapper, Mapper>();
            builder.Services.AddAutoMapper(typeof(EventMappingProfile));
            builder.Services.AddAutoMapper(typeof(WebMappingProfile));
            // builder.Services.AddScoped<IEventUnitOfWorks, EventAppService>();
            

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                    ));
            /*builder.Services.AddDbContext<EventDomainDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                    ));*/
            builder.Services.AddDbContext<EventDomainDbContext>();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IEventUnitOfWorks, EventUnitOfWorks>();
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<IEventAppService, EventAppService>();
            builder.Services.AddScoped<IExceptionManager, ExceptionManager>();
            builder.Services.AddSingleton<Company.Project.Core.Logging.ILogger, Company.Project.Loggig.NLog.Logger>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
