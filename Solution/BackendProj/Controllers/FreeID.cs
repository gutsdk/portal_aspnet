namespace BackendProj.Controllers
{
    public class FreeID
    {
        public static SortedSet<int> FreeIDs = new SortedSet<int>();

        public static int GetFirst()
        {
            if (FreeIDs.Count == 0) return 0;
            
            int temp = FreeIDs.First();
            FreeIDs.Remove(temp);
            return temp;
        }
    }
}
    