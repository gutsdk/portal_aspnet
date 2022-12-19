using BackendProj.Controllers;
using BackendProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendProj.Pages
{
    public class ExtraEducationsPageModel : PageModel
    {
        public User user { get; set; }
        public List<ExtraEducation> educations { get; set; }
        public List<ExtraEducation> usersEducations { get; set; }
        public void OnGet()
        {
            user = HttpContext.Session.Get<User>(IndexModel.userId);
            educations = ExtraEducationControll.GetListOfExtraEducations();
            usersEducations = ExtraEducationControll.GetExtraEducationsOfUser(user.ExtraEducationsList);
        }
        public IActionResult OnPostAdd(int educationId)
        {
            user = HttpContext.Session.Get<User>(IndexModel.userId);
            user.ExtraEducationsList.Add(educationId.ToString());
            ChangeDB.SetUser(user);
            HttpContext.Session.Remove(IndexModel.userId);
            HttpContext.Session.Set(IndexModel.userId, user);
            return RedirectToPage("/ExtraEducationsPage");
        }
        public IActionResult OnPostDelete(int educationId)
        {
            user = HttpContext.Session.Get<User>(IndexModel.userId);
            user.ExtraEducationsList.Remove(educationId.ToString());
            ChangeDB.SetUser(user);
            HttpContext.Session.Remove(IndexModel.userId);
            HttpContext.Session.Set(IndexModel.userId, user);
            return RedirectToPage("/ExtraEducationsPage");
        }
    }
}
