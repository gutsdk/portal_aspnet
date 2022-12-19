using BackendProj.Models;
using System.Drawing;

namespace BackendProj.Controllers
{
    public class Tests
    {
        public static void DBInit()
        {
            AppDbContext db = new AppDbContext();
            

            Image img = Image.FromFile("wwwroot\\images\\ImageOfPerson1.jpeg");
            ImageConverter converter = new ImageConverter();
            byte[] image_first_person = (byte[])converter.ConvertTo(img, typeof(byte[]));

            img = Image.FromFile("wwwroot\\images\\ImageOfPerson2.jpeg");
            byte[] image_second_person = (byte[])converter.ConvertTo(img, typeof(byte[]));

            List<User> userList = new List<User>();
            List<ExtraEducation> extraEducations = new List<ExtraEducation>() 
            {   new ExtraEducation {Id = 1, Theme = "Development: организация, разработка проекта, управление рисками, оценка", 
                Description = "Расскажем от А до Я все принципы и тонкости такой сферы деятельности, как Development", Duration = "8760 ч."}, 
                new ExtraEducation {Id = 2, Theme = "Производственный менеджмент", 
                Description = "На курсе рассматривается эффективные способы ведения менеджерской деятельности на производстве", Duration = "96 ч."}, 
                new ExtraEducation {Id = 3, Theme = "Производственный персонал: управление, вовлечение, эффективность", 
                Description = "Научим вас работать с персоналом: управлять людьми, вовлекать их в ту деятельность, которой они не хотят заниматься и т.д.", Duration = "72 ч."}, 
                new ExtraEducation {Id = 4, Theme = "Руководитель службы безопасности", 
                Description = "Потребность в руководителях СБ существует как у предприятий, так и у крупных компаний. Научим вам быть нужными в этой сфере", Duration = "4320 ч."}, 
                new ExtraEducation {Id = 5, Theme = "Директор по персоналу", 
                Description = "Вы получите прочные теоретические знания и практические навыки в области управления персоналом, изучите проблемы взаимодействия с людьми", Duration = "120 ч."}};
            db.ExtraEducations.AddRange(extraEducations);
            User user1 = new User
            {
                login = "chopix",
                password = "123456",
                role = 0,
                ExtraEducationsList = new List<string> { "1", "3" },
                Data = new Person
                {
                    FIO = "Иванов Георгий Иванович",
                    Doljnost = "Глава заместителей генерального директора",
                    DateOfEmploy = "24.12.2012",
                    Birthday = "24.12.2002",
                    Experience = DateTime.Now.Year - int.Parse("24.12.2012".Substring(6)),
                    PrevWorkPlace = "EPAM - Senior разработчик на C++",
                    Education = "Высшее образование - специалитет, ВМКСиС - ИжГТУ",
                    EducationOutsideUniversity = "Курс повышения английского языка до уровня C1 - 120 ч.",
                    Image = image_first_person,
                    About = "Самый ироничный, самый добрый, самый честный стример, герой Рунета 2009 года, обозреватель еды",
                    Achievments = "Самый лучший стример 2009"
                }
            };

            userList.Add(user1);

            User user2 = new User
            {
                login = "pondix",
                password = "456789",
                role = 1,
                ExtraEducationsList = new List<string> { "2", "4", "5" },
                Data = new Person
                {
                    FIO = "Петров Александр Игоревич",
                    Doljnost = "Генеральный директор",
                    DateOfEmploy = "20.10.2019",
                    Birthday = "14.08.2013",
                    Experience = DateTime.Now.Year - int.Parse("20.10.2019".Substring(6)),
                    PrevWorkPlace = "СКБ Контур - Директор по персоналу",
                    Education = "Высшее образование - магистратура, Менеджмент - УдГУ",
                    EducationOutsideUniversity = "",
                    Image = image_second_person,
                    About = "Люблю жизнь, но больше люблю ее изучать. Сложные вещи простым языком. Глубокий анализ, непривычный ход мысли и противоинтуитивные факты!",
                    Achievments = "МСМК по волевой борьбе"
                }
            };

            userList.Add(user2);

            foreach(User user in userList)
            {
                user.Salt = Crypto.CreateSalt(5);
                user.password = Crypto.GenerateHash(user.password, user.Salt);
            }

            ChangeDB.AddUser(user1);
            ChangeDB.AddUser(user2);
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
