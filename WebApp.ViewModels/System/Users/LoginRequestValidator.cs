using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.ViewModels.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(X => X.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(X => X.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is at least 6 character ");
        }
    }
}
