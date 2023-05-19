namespace MailTracker.Application.Dto
{
    public class GetEmailsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string RecipientName { get; set; }
        public string SenderName { get; set; }
        public string Content { get; set; }
        public IEnumerable<GetDocumentDto> Documents { get; set; }
    }
}
