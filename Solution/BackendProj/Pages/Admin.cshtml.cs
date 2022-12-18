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
        public IActionResult OnPostEdit(int ID)
        {
            EditorPageModel.ID = ID;
            EditorPageModel.IsEditor = true;
            return RedirectToPage("/EditorPage");
        }
        public IActionResult OnPostAdd(int ID)
        {
            EditorPageModel.ID = 0;
            EditorPageModel.IsEditor = false;
            return RedirectToPage("/EditorPage");
        }
    }
}
