using BackendProj.Controllers;
using BackendProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Drawing;

namespace BackendProj.Pages
{
    public class EditorPageModel : PageModel
    {
        public static int ID{ get; set; }   
        public static bool IsEditor { get; set; }
        public User user { get; set; }
        public static byte[] NoImg { get; set; }
        public static byte[] UploadedImg { get; set; }
        public void OnGet()
        {
            user = Authorization.GetUser(ID);
            ImageConverter converter = new ImageConverter();
            NoImg = (byte[])converter.ConvertTo(Image.FromFile("wwwroot\\images\\Noname.JPG"), typeof(byte[]));
        }
        public IActionResult OnPostSave(string fio, string about, string login, string Password, string Role, string birthD, string educ, string doljn, string date, IFormFile photo)
        {
            user = Authorization.GetUser(ID);
            if (photo != null)
            {
                var stream = new MemoryStream((int)photo.Length);
                photo.CopyTo(stream);
                UploadedImg = stream.ToArray();
            }
            else {
                UploadedImg = NoImg;
            }

            if (!IsEditor)
            {
                User newUser = new User
                {
                    login = login,
                    password = Password,
                    role = int.Parse(Role),
                    Data = new Person
                    {
                        FIO = fio,
                        Doljnost = doljn,
                        DateOfEmploy = date,
                        Birthday = birthD,
                        Experience = DateTime.Now.Year - int.Parse(date.Substring(6)),
                        Education = educ,
                        Image = UploadedImg,
                        About = about
                    }
                };
                newUser.Salt = Crypto.CreateSalt(5);
                newUser.password = Crypto.GenerateHash(newUser.password, newUser.Salt);
                ChangeDB.AddUser(newUser);
            }
                
            else
            {
                User newUser = user;
                newUser.login = login;
                newUser.password = user.password;
                newUser.role = int.Parse(Role);
                newUser.Data.FIO = fio;
                newUser.Data.Doljnost = doljn;
                newUser.Data.DateOfEmploy = date;
                newUser.Data.Birthday = birthD;
                newUser.Data.Experience = DateTime.Now.Year - int.Parse(date.Substring(6));
                newUser.Data.Education = educ;
                newUser.Data.About = about;
                if (photo != null) newUser.Data.Image = UploadedImg;
                ChangeDB.SetUser(newUser);
            }
            if (ID == Convert.ToInt32(IndexModel.userId))
            {
                HttpContext.Session.Remove(IndexModel.userId);
                HttpContext.Session.Set(IndexModel.userId, user);
            }
            return RedirectToPage("/Admin");

        }
        public IActionResult OnPostDelete()
        {
            user = Authorization.GetUser(ID);
            if(IsEditor)
                Controllers.ChangeDB.DeleteUser(user);
            return RedirectToPage("/Admin");
        }
    }
}
