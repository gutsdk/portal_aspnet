using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BackendProj.Models;
using BackendProj.Controllers;
using System.Drawing;

namespace BackendProj.Pages
{
    public class IndexModel : PageModel
    {

        public IActionResult OnPost(string login, string password)
        {
            if (Authorization.GetUser(login, password) == null)
                return NotFound("Пользователь не найден");
            AccountPageModel.password = password;
            AccountPageModel.login = login; 
            return RedirectToPage("/AccountPage");
        }
    }
}