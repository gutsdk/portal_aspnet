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

            //тест запроса по логину и паролю
            Models.User? user = Authorization.GetUser("ROck", "123155");

            //Задание картинки
            Image img = Image.FromFile("wwwroot\\ImageOfPerson1.jpeg");
            ImageConverter converter = new ImageConverter();
            byte[] image_first_person = (byte[])converter.ConvertTo(img, typeof(byte[]));

            img = Image.FromFile("wwwroot\\ImageOfPerson2.jpeg");
            byte[] image_second_person = (byte[])converter.ConvertTo(img, typeof(byte[]));

            //Добавляем в БД
            using (BackendProj.Controllers.AppContext db = new BackendProj.Controllers.AppContext())
            {
                // создаем два объекта User
                User user1 = new User { login = "ROck", password = "123145", Data = new Person { FIO = "Stepanov Kolya Robertovi4", Birthday = "24.12.02", Image = image_first_person } };
                User user2 = new User { login = "Alice", password = "12565124", Data = new Person { FIO = "Kongratev Mihail Vasilievi4", Birthday = "16.03.13", Image = image_second_person } };

                user1.Salt = Crypto.CreateSalt(5);
                string hashpassword1 = Crypto.GenerateHash(user1.password, user1.Salt);
                string oldpassword = user1.password;
                user1.password = hashpassword1;
                if(Crypto.AreEqual(oldpassword,hashpassword1, user1.Salt))
                {
                    Console.WriteLine("Пароли совпадают");
                }    

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
                    Console.WriteLine($"{u.Id}.Логин: {u.login} Пароль: {u.password}  ФИО: {u.Data.FIO}  День рождения: {u.Data.Birthday}");
                }
            }
        }
    }
}