using MailTracker.Domain.Entities;

namespace MailTracker.Application.Interfaces.Repositories
{
    public interface IDocumentRepository
    {
        Task SaveDocumentAsync(Document document);
    }
}
