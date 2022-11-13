using BackendProj.Models;
using System.Drawing;

namespace BackendProj.Controllers
{
    public class Tests
    {
        public static void DBInit()
        {
            AppContext db = new AppContext();

            Image img = Image.FromFile("wwwroot\\ImageOfPerson1.jpeg");
            ImageConverter converter = new ImageConverter();
            byte[] image_first_person = (byte[])converter.ConvertTo(img, typeof(byte[]));

            img = Image.FromFile("wwwroot\\ImageOfPerson2.jpeg");
            byte[] image_second_person = (byte[])converter.ConvertTo(img, typeof(byte[]));

            List<User> userList = new List<User>();

            User user1 = new User
            {
                login = "chopix",
                password = "123456",
                Data = new Person
                {
                    FIO = "Tolstolobikov Mihail Ivanich",
                    Birthday = "24.12.2002",
                    Image = image_first_person
                }
            };

            userList.Add(user1);

            User user2 = new User
            {
                login = "pondix",
                password = "456789",
                Data = new Person
                {
                    FIO = "Glavgadov Kaban Kabanovich",
                    Birthday = "14.08.2013",
                    Image = image_second_person
                }
            };

            userList.Add(user2);

            foreach(User user in userList)
            {
                user.Salt = Crypto.CreateSalt(5);
                user.password = Crypto.GenerateHash(user.password, user.Salt);
            }

            db.Users.AddRange(user1, user2);
            db.SaveChanges();
        }

        public static void GetDB()
        {
            AppContext db = new AppContext();

            var users = db.Users.ToList();
            Console.WriteLine("Users list: ");
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.Логин: {u.login} Пароль: {u.password}  ФИО: {u.Data.FIO}  День рождения: {u.Data.Birthday}");
            }
        }
    }
}
