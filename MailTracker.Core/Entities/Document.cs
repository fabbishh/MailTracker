namespace MailTracker.Domain.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public int EmailId { get; set; }
        public Email Email { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
