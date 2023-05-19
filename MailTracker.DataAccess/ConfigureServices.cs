using MailTracker.Application.Interfaces.Repositories;
using MailTracker.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MailTracker.DataAccess
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<MailDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            });

            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();

            return services;
        }
    }
}
