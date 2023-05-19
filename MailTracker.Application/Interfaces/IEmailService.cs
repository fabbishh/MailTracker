using MailTracker.Application.Dto;

namespace MailTracker.Application.Interfaces
{
    public interface IEmailService
    {
        Task SaveEmail(AddEmailRequest email);
        Task<IEnumerable<GetEmailsResponse>> GetAllEmailsAsync();
    }
}
