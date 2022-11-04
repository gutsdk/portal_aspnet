using System;
using System.Linq;
using BackendProj.Models;
using BackendProj.Controllers;

namespace BackendProj
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

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

            app.MapRazorPages();

            app.Run();
            //Добавляем в БД
            using (BackendProj.Controllers.AppContext db = new BackendProj.Controllers.AppContext())
            {
                // создаем два объекта User
                User user1 = new User { login = "ROck", password = "123145" };
                User user2 = new User { login = "Alice", password = "12565124" };

                // добавляем их в бд
                db.Users.AddRange(user1, user2);
                db.SaveChanges();
            }

            //Получение из БД и вывод в консоль
            using (BackendProj.Controllers.AppContext db = new BackendProj.Controllers.AppContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("Users list: ");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.login} - {u.password}");
                }
            }
        }
    }
}