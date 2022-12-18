using BackendProj.Models;

namespace BackendProj.Controllers
{
    public class ExtraEducationControll
    {
        public static List<ExtraEducation> GetListOfExtraEducations()
        {
            AppDbContext db = new AppDbContext();
            var list = db.ExtraEducations.ToList();
            return list;
        }

        public static List<ExtraEducation> GetExtraEducationsOfUser(List<string> ExEducID)
        {
            AppDbContext db = new AppDbContext();
            var list = new List<ExtraEducation>();
            foreach(string id in ExEducID)
            {
                var temp = db.ExtraEducations.Find(int.Parse(id));
                if(temp != null)
                {
                    list.Add(temp);
                }
            }
            return list;
        }
    }
}
