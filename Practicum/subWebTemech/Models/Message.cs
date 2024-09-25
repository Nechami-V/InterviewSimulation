namespace subWebTemech.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int? ParentMessageId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
        public ThreadMessage Thread { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public Message ParentMessage { get; set; }
    }
}
