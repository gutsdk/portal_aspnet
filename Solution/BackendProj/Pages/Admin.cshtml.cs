using BackendProj.Controllers;
using BackendProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendProj.Pages
{
    public class AdminModel : PageModel
    {
        public AppDbContext db = new AppDbContext();
        public void OnGet()
        {
        }
        public IActionResult OnPost(int ID)
        {
            EditorPageModel.ID = ID;
            return RedirectToPage("/EditorPage");
        }
    }
}
