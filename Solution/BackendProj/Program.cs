using System;
using System.Linq;
using BackendProj.Models;
using BackendProj.Controllers;
using System.Drawing;
using Microsoft.AspNetCore.Components.Web.Virtualization;


namespace BackendProj
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AppDbContext db = new AppDbContext();

            User? user = db.Users.FirstOrDefault(u => u.Id == 2);
            ChangeDB.DeleteUser(user);

            Tests.DBInit();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddRazorPages();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            { 
                options.Cookie.Name = ".IRZ.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseSession();

            app.MapRazorPages();

            app.Run();
        }
    }
}