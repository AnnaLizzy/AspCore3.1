using FluentValidation;
using System;

namespace WebApp.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("Không bỏ trống trường này !")
                .MaximumLength(200).WithMessage("Tên không quá 200 kí tự !");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Không bỏ trống trường này !")
                .MaximumLength(200).WithMessage("Họ không quá 200 kí tự !");
            RuleFor(c => c.Dob).GreaterThan(DateTime.Now.AddYears(-100))
                .WithMessage("Nhập lại !");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Không bỏ trống trường này !")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Định dạng Email không đúng !");
            RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Không bỏ trống trường này !");
            RuleFor(c => c.UserName).NotEmpty().WithMessage("Nhập tên người dùng !");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Nhập mật khẩu !")
                .MinimumLength(6).WithMessage("Mật khẩu ít nhất 6 kí tự !");
            RuleFor(c => c).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Mật khẩu nhập lại không đúng !");
                }
            });
        }
    }
}
