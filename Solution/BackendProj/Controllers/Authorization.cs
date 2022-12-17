using BackendProj.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendProj.Controllers
{
    public class Authorization
    {
        public static User? GetUser(string login, string password)
        {
            AppDbContext db = new AppDbContext();
            if (login == null || password == null) return null;
            var user = db.Users.AsEnumerable().FirstOrDefault(user => user.login == login && Crypto.AreEqual(password, user.password, user.Salt));

            return user;
        }
    }
}