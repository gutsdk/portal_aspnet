using BackendProj.Models;

namespace BackendProj.Controllers
{
    public class Authorization
    {
        public AppContext db;

        public Authorization()
        {
            db = new AppContext();
        }

        public User? GetUser(string login, string password)
        {
            var user = db.Users.Where(user => user.login == login && user.password == password).ToList();

            if (user == null || !user.Any())
            {
                return null;
            }
            return user[0];
        }
    }
}