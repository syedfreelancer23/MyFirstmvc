using Microsoft.EntityFrameworkCore;
using MyFirstmvc.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using MyFirstmvc.Models;
using System.Net;
public  class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
       // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
        // Configure DbContext with connection string
        builder.Services.AddDbContext<UsersContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        //add logging 
        builder.Logging.ClearProviders();
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();
        builder.Services.AddRazorPages();
        builder.Services.AddLogging(logging =>
       {
           logging.AddConsole();
           logging.AddDebug();
           logging.AddFilter("Microsoft.AspNetCore", LogLevel.Warning);

       }); var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                SeedData.Initialize(services);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        // app.MapControllerRoute(
        //     name: "default",
        //     pattern: "{controller=Home}/{action=Index}/{id?}"
        //     );

        IApplicationBuilder applicationBuilder = app.UseEndpoints(endpoints =>
        {
        endpoints.MapRazorPages();
            endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
        });
        app.Run();
    }
}