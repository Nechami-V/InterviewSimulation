namespace subWebTemech.Models
{
    public class ThreadMessage
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public DateTime Date { get; set; }
        public int? LastMessageId { get; set; }
        public int CountMessage { get; set; }
    }
}
