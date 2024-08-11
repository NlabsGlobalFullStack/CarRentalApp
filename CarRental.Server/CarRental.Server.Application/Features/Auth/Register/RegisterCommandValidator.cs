using FluentValidation;

namespace CarRental.Server.Application.Features.Auth.Register;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(p => p.Email)
            .MinimumLength(10)
            .WithMessage("Email address must be at least 10 characters!");

        RuleFor(p => p.Email)
            .EmailAddress()
            .WithMessage("Unconfirmed email address!");

        RuleFor(p => p.FirstName)
            .MinimumLength(3)
            .WithMessage("FirstName must be at least 3 characters!");

        RuleFor(p => p.LastName)
            .MinimumLength(3)
            .WithMessage("LastName must be at least 3 characters!");

        RuleFor(p => p.Password)
            .MinimumLength(1)
            .WithMessage("Password must be at least 1 characters!");

        RuleFor(p => p.RePassword)
            .MinimumLength(1)
            .WithMessage("Re Password must be at least 1 characters!");

        RuleFor(p => p.RePassword)
            .GreaterThanOrEqualTo(p => p.Password)
            .WithMessage("Repeat password Does not match password!");
    }
}
