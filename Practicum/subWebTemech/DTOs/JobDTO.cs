namespace subWebTemech.DTOs
{
    public class JobDTO
    {
        public int JobId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime PostedDate { get; set; }
        public int CategoryId { get; set; }
        public int ExperienceLevelId { get; set; }
        public int LocationId { get; set; }
        public int LanguageId { get; set; }
        public int JobTypeId { get; set; }
    }
}
