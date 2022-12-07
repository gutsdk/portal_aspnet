using BackendProj.Models;

namespace BackendProj.Controllers
{
    public class ChangeDB
    {
        public static void SetUser(User user)
        {
            AppDbContext db = new AppDbContext();

            db.Update(user);
            db.SaveChanges();
        }
    }
}