using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BackendProj.Models;
using BackendProj.Controllers;
using System.Drawing;

namespace BackendProj.Pages
{
    public class AuthErrorModel : PageModel
    {
        public IActionResult OnPost(string login, string password)
        {
            if (Authorization.GetUser(login, password) == null)
                return RedirectToPage("/AuthError");

            var user = Authorization.GetUser(login, password);
            IndexModel.userId = user.Id.ToString();

            HttpContext.Session.Set<User>(IndexModel.userId, user);
            return RedirectToPage("/AccountPage");
        }
    }
}
