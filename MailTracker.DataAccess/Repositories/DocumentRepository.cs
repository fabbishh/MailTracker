using MailTracker.Application.Interfaces.Repositories;
using MailTracker.Domain.Entities;

namespace MailTracker.DataAccess.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly MailDbContext _context;
        public DocumentRepository(MailDbContext context)
        {
            _context = context;
        }

        public async Task SaveDocumentAsync(Document document)
        {
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
        }
    }
}
