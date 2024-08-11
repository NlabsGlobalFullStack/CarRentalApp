using FluentValidation;

namespace CarRental.Server.Application.Features.Auth.Login;
public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.UserNameOrEmail)
            .MinimumLength(3)
            .WithMessage("Username or email address must be at least 3 characters!");
        RuleFor(p => p.Password)
            .MinimumLength(1)
            .WithMessage("Password must be at least 1 character!");
    }
}