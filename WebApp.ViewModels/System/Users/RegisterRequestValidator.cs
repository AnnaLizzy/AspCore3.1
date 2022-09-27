using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(c => c.FirtName).NotEmpty().WithMessage("First Name is required")
                .MaximumLength(200).WithMessage("First Name is not over 200 charecters");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("First Name is required")
                .MaximumLength(200).WithMessage("First Name is not over 200 charecters");
            RuleFor(c => c.Dob).GreaterThan(DateTime.Now.AddYears(-100))
                .WithMessage("Nhap lai");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match");
            RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Phone Number is required");
            RuleFor(c => c.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is at least 6 character ");
            RuleFor(c => c).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm password is not match");
                }
            });
        }
    }
}
