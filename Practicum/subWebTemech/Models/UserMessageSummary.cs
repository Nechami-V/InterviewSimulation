namespace subWebTemech.Models
{
    public class UserMessageSummary
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UnreadInBoxCount { get; set; }
        public int? LastInboxId { get; set; }
        public int? LastSentboxId { get; set; }
        public User User { get; set; }
    }
}
