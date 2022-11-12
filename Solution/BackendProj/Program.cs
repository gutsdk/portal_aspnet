using System;
using System.Linq;
using BackendProj.Models;
using BackendProj.Controllers;
using System.Drawing;

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

            //���� ������� �� ������ � ������
            var authorization = new Authorization();
            Models.User user = authorization.GetUser("ROck", "123145");

            //������� ��������
            Image img = Image.FromFile("wwwroot\\ImageOfPerson1.jpeg");
            ImageConverter converter = new ImageConverter();
            byte[] image_first_person = (byte[])converter.ConvertTo(img, typeof(byte[]));

            img = Image.FromFile("wwwroot\\ImageOfPerson2.jpeg");
            byte[] image_second_person = (byte[])converter.ConvertTo(img, typeof(byte[]));

            //��������� � ��
            using (BackendProj.Controllers.AppContext db = new BackendProj.Controllers.AppContext())
            {
                // ������� ��� ������� User
                User user1 = new User { login = "ROck", password = "123145", Data = new Person { Name = "Kolya", Age = 19, Surname = "Kupalov", Image = image_first_person } };
                User user2 = new User { login = "Alice", password = "12565124", Data = new Person { Name = "Sanya", Age = 23, Surname = "Kropashev", Image = image_second_person } };

                // ��������� �� � ��
                db.Users.AddRange(user1, user2);
                db.SaveChanges();
            }

            //��������� �� �� � ����� � �������
            using (BackendProj.Controllers.AppContext db = new BackendProj.Controllers.AppContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("Users list: ");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.�����: {u.login} ������: {u.password}  ���: {u.Data.Name}  �������: {u.Data.Surname}  �������: {u.Data.Age}");
                }
            }
        }
    }
}