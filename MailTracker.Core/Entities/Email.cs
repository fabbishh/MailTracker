namespace MailTracker.Domain.Entities
{
    public class Email
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int RecipientId { get; set; }
        public Employee Recipient { get; set; }
        public int SenderId { get; set; }
        public Employee Sender { get; set; }
        public string Content { get; set; }
        public IEnumerable<Document> Documents { get; set; }
    }
}
