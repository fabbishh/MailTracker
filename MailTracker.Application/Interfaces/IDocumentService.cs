using MailTracker.Application.Dto;

namespace MailTracker.Application.Interfaces
{
    public interface IDocumentService
    {
        Task SaveDocumentsAsync(IEnumerable<DocumentDto> documents, int emailId);
    }
}
