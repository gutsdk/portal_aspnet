using BackendProj.Models;
using BackendProj.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;

namespace BackendProj.Pages
{
    public class AccountPageModel : PageModel
    {
        public User user { get; set; } 
        public void OnPost(string about)
        {
            user = HttpContext.Session.Get<User>(IndexModel.userId);
            if (user.Data.About == about)
                return;
            user.Data.About = about;    
            ChangeDB.SetUser(user);
            return;
        }

        public void OnGet(string log, string pass)
        {
            user = HttpContext.Session.Get<User>(IndexModel.userId);
        }
    }
}
