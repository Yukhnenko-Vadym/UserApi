using FluentValidation;
using TestTask.Requests;

namespace TestTask.Validation;

public class UserValidator : AbstractValidator<CreateUserRequest>
{
    public UserValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("FullName is required")
            .MinimumLength(2).MaximumLength(60).WithMessage("FullName must be at least 2 characters but no more than 60")
            .Matches("^[a-zA-Z\\s'-]+$").WithMessage("FullName must contain only Latin letters, spaces, hyphens or apostrophes");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("DateOfBirth is required")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("DateOfBirth cannot be a future date");
    }
}