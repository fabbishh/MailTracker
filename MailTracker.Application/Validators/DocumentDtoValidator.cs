using FluentValidation;
using MailTracker.Application.Dto;

namespace MailTracker.Application.Validators
{
    public class DocumentDtoValidator : AbstractValidator<DocumentDto>
    {
        public DocumentDtoValidator()
        {
            RuleFor(document => document.Name)
                .NotEmpty();

            RuleFor(document => document.FileBytes)
                .NotEmpty()
                .Must(bytes => bytes.Length > 0);
        }
    }
}
