using BackendProj.Models;
using BackendProj.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;

namespace BackendProj.Pages
{
    public class AccountPageModel : PageModel
    {
        public static  string password { get; set; }
        public static string login { get; set; }    
        public User user { get; set; }
        public void OnGet(string log, string pass)
        {
            user = Authorization.GetUser(login, password);
        }
    }
}
