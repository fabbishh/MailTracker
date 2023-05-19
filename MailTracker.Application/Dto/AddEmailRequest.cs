namespace MailTracker.Application.Dto
{
    public class AddEmailRequest
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int RecipientId { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; }
        public IEnumerable<DocumentDto> Documents { get; set; }
    }
}
