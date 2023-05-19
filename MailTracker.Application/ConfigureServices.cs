using FluentValidation;
using FluentValidation.AspNetCore;
using MailTracker.Application.Dto;
using MailTracker.Application.Interfaces;
using MailTracker.Application.Services;
using MailTracker.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace MailTracker.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<DocumentDtoValidator>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDocumentService, DocumentService>();

            

            return services;
        }
    }
}
