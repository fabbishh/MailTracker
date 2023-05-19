using MailTracker.Application.Dto;
using MailTracker.Application.Interfaces;
using MailTracker.Application.Interfaces.Repositories;
using MailTracker.Domain.Entities;

namespace MailTracker.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task SaveDocumentsAsync(IEnumerable<DocumentDto> documents, int emailId)
        {
            foreach (var document in documents)
            {
                var filePath = await SaveFileAsync(document.FileBytes, document.Name);
                var documentToSave = new Document
                {
                    EmailId = emailId,
                    Name = document.Name,
                    Path = filePath,
                };

                await _documentRepository.SaveDocumentAsync(documentToSave);
            }
        }

        private async Task<string> SaveFileAsync(byte[] fileBytes, string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Documents");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filePath = Path.Combine(path, fileName);

            await File.WriteAllBytesAsync(filePath, fileBytes);

            return filePath;
        }
    }
}
