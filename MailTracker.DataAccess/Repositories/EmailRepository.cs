using MailTracker.Application.Interfaces.Repositories;
using MailTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailTracker.DataAccess.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly MailDbContext _context;
        public EmailRepository(MailDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Email>> GetAllAsync()
        {
            return await _context.Emails
                .Include(e => e.Sender)
                .Include(e => e.Recipient)
                .Include(e => e.Documents)
                .ToListAsync();
        }

        public async Task<int> SaveEmail(Email email)
        {
            await _context.Emails.AddAsync(email);
            await _context.SaveChangesAsync();
            return email.Id;
        }
    }
}
