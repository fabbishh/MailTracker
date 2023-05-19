using MailTracker.Domain.Entities;

namespace MailTracker.Application.Interfaces.Repositories
{
    public interface IEmailRepository
    {
        Task<int> SaveEmail(Email email);
        Task<IEnumerable<Email>> GetAllAsync();
    }
}
