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
        public static void AddUser(User user)
        {
            AppDbContext db = new AppDbContext();

            user.Id = FreeID.GetFirst();
            db.Users.Add(user);
            db.SaveChanges();
        }
        public static void DeleteUser(User user) 
        {
            AppDbContext db = new AppDbContext();
            
            FreeID.FreeIDs.Add(user.Id);
            db.Remove(user);
            db.SaveChanges();
        }
    }
}