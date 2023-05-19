using FluentValidation;
using MailTracker.Application.Dto;

namespace MailTracker.Application.Validators
{
    public class AddEmailRequestValidator : AbstractValidator<AddEmailRequest>
    {
        public AddEmailRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty();

            RuleFor(request => request.Date)
                .Must(date => date.Date >= DateTime.Today);

            RuleFor(request => request.RecipientId)
                .GreaterThan(0)
                .Must((request, recipientId) => recipientId != request.SenderId);

            RuleFor(request => request.SenderId)
                .GreaterThan(0);

            RuleFor(request => request.Content)
                .NotEmpty();

            RuleForEach(request => request.Documents)
                .SetValidator(new DocumentDtoValidator());
        }
    }
}
