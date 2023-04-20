using Care.Data;
using Microsoft.EntityFrameworkCore;
using Paharamacyapi.Data;

namespace Care
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //informing the application to use DbContext to connect and create a dayabase and table
            /*builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
           */
             builder.Services.AddDbContext<PharamaAPIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PharamaapiConnectionString")));

            //it will go to applicationdbcontect class then it will provide options that will be sent to the base class
            //the methodin line 17 will let the app know to find the connection string having name "DefaultConnection"

            //2. swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
           
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}