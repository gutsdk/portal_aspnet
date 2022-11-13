using BackendProj.Models;

namespace BackendProj.Controllers
{
    public class ChangeDB
    {
        public static void SetUser(User user)
        {
            AppContext db = new AppContext();

            db.Update(user);
            db.SaveChanges();
        }
    }
}