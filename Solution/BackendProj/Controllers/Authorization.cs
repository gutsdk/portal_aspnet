using BackendProj.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendProj.Controllers
{
    public class Authorization
    {
        public static User? GetUser(string login, string password)
        {
            AppContext db = new AppContext();

            var user = db.Users.AsEnumerable().Where(user => user.login == login && Crypto.AreEqual(password, user.password, user.Salt)).ToList();

            if (user == null || !user.Any())
            {
                return null;
            }
            return user[0];
        }
    }
}