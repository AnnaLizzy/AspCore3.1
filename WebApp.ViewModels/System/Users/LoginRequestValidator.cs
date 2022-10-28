using FluentValidation;

namespace WebApp.ViewModels.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(X => X.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(X => X.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Mật khẩu gồm 6 kí tự ! ");
        }
    }
}
