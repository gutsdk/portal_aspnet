namespace BackendProj.Models
{
    public class ExtraEducation
    {
        public int Id { get; set; }
        public string? Theme { get; set; }
        public string? Duration { get; set; }
        public int? ExtraEducationId { get; set; }
        public virtual User User { get; set; }
    }
}
