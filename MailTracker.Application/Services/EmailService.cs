using MailTracker.Application.Dto;
using MailTracker.Application.Interfaces;
using MailTracker.Application.Interfaces.Repositories;
using MailTracker.Domain.Entities;

namespace MailTracker.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IDocumentService _documentService;
        public EmailService(IEmailRepository emailRepository, IDocumentService documentService)
        {
            _emailRepository = emailRepository;
            _documentService = documentService;
        }

        public async Task<IEnumerable<GetEmailsResponse>> GetAllEmailsAsync()
        {
            var mails = await _emailRepository.GetAllAsync();
            var mailsList = new List<GetEmailsResponse>();
            foreach (var mail in mails.ToList())
            {
                var documents = new List<GetDocumentDto>();
                foreach (var doc in mail.Documents)
                {
                    documents.Add(new GetDocumentDto
                    {
                        Id = doc.Id,
                        FileName = doc.Name,
                        Path = doc.Path
                    });
                }

                mailsList.Add(new GetEmailsResponse
                {
                    Id = mail.Id,
                    Content = mail.Content,
                    Date = mail.Date,
                    Name = mail.Name,
                    RecipientName = mail.Recipient.Name,
                    SenderName = mail.Sender.Name,
                    Documents = documents
                });
            }
            return mailsList;
        }

        public async Task SaveEmail(AddEmailRequest email)
        {
            var mail = new Email
            {
                Name = email.Name,
                Date = email.Date,
                Content = email.Content,
                RecipientId = email.RecipientId,
                SenderId = email.SenderId,
            };
            var emailId = await _emailRepository.SaveEmail(mail);
            await _documentService.SaveDocumentsAsync(email.Documents, emailId);
        }
    }
}
