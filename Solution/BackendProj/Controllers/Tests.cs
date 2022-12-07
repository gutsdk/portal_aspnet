using BackendProj.Models;
using System.Drawing;

namespace BackendProj.Controllers
{
    public class Tests
    {
        public static void DBInit()
        {
            AppDbContext db = new AppDbContext();

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
                role = 0,
                Data = new Person
                {
                    FIO = "Tolstolobikov Mihail Ivanich",
                    Doljnost = "Глава заместителей генерального директора",
                    DateOfEmploy = "24.12.2012",
                    Birthday = "24.12.2002",
                    PhoneNumber = "82281337228",
                    Experience = DateTime.Now.Year - int.Parse("24.12.2012".Substring(6)),
                    Education = "Высшее образование - специалитет, ВМКСиС",
                    Image = image_first_person,
                    About = "Самый ироничный, самый добрый, самый честный стример, герой Рунета 2009 года, обозреватель еды"
                }
            };

            userList.Add(user1);

            User user2 = new User
            {
                login = "pondix",
                password = "456789",
                role = 1,
                Data = new Person
                {
                    FIO = "Glavgadov Kaban Kabanovich",
                    Doljnost = "Генеральный директор",
                    DateOfEmploy = "20.10.2019",
                    Birthday = "14.08.2013",
                    PhoneNumber = "88005553535",
                    Experience = DateTime.Now.Year - int.Parse("20.10.2019".Substring(6)),
                    Education = "Высшее образование - магистратура, Менеджмент",
                    Image = image_second_person,
                    About = "Люблю жизнь, но больше люблю ее изучать. Сложные вещи простым языком. Глубокий анализ, непривычный ход мысли и противоинтуитивные факты!"
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
            AppDbContext db = new AppDbContext();

            var users = db.Users.ToList();
            Console.WriteLine("Users list: ");
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.Логин: {u.login} Пароль: {u.password}  ФИО: {u.Data.FIO}  День рождения: {u.Data.Birthday}");
            }
        }
    }
}
