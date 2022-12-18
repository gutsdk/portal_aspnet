using BackendProj.Controllers;
using BackendProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendProj.Pages
{
    public class EditorPageModel : PageModel
    {
        public static int ID{ get; set; }   
        public User user { get; set; }
        public void OnGet()
        {
            user = Authorization.GetUser(ID);
        }
        public void OnPost(string fio, string about, string login, string Password, string Role, string birthD, string phone, string educ, string doljn, string date, string exp)
        {
            User newUser = new User();
            newUser.login = login;
            newUser.password = Password;
            newUser.role = int.Parse(Role);
            newUser.Data.Birthday = birthD;
            newUser.Data.PhoneNumber = phone;
            newUser.Data.Education = educ;
            newUser.Data.Doljnost = doljn;
            newUser.Data.DateOfEmploy= date;
            newUser.Data.Experience = int.Parse(exp);
            newUser.Data.About = about;
            newUser.Data.FIO = fio; 
            newUser.Salt = Crypto.CreateSalt(5);
            user.password = Crypto.GenerateHash(user.password, user.Salt);
            if (user== null)
                ChangeDB.AddUser(newUser);
            else
                ChangeDB.SetUser(newUser);
                
        }
    }
}
