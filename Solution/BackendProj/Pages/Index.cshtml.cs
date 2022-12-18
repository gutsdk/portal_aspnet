using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BackendProj.Models;
using BackendProj.Controllers;
using System.Drawing;

namespace BackendProj.Pages
{
    public class IndexModel : PageModel
    {
        public static string userId { get; set; } 
        public IActionResult OnPost(string login, string password)
        {
            if (Authorization.GetUser(login, password) == null)
                return RedirectToPage("/AuthError");

            var user = Authorization.GetUser(login, password);
            userId = user.Id.ToString();

            HttpContext.Session.Set<User>(userId, user);
                return RedirectToPage("/AccountPage");
        }
        public void OnGet()
        {
            if (HttpContext.Session.Keys.Contains(userId))
            {
                HttpContext.Session.Remove(userId);
            }
        }
    }
}