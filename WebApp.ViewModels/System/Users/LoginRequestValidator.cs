using FluentValidation;

namespace WebApp.ViewModels.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(X => X.UserName).NotEmpty().WithMessage("Nhập tên người dùng");
            RuleFor(X => X.Password).NotEmpty().WithMessage("Nhập mật khẩu")
                .MinimumLength(6).WithMessage("Mật khẩu gồm 6 kí tự ! ");
        }
    }
}
