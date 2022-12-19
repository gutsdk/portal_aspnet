using BackendProj.Controllers;
using BackendProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendProj.Pages
{
    public class ExtraEducationsPage : PageModel
    {
        public User user { get; set; }
        public void OnGet()
        {
            user = HttpContext.Session.Get<User>(IndexModel.userId);
        }
        public void OnPost()
        {

        }
        public void OnDelete()
        {

        }
    }
}
