using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOCManager.WebApi.Models;

namespace TOCManager.WebApi.Infrastructure.Validators
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(r => r.Username).NotEmpty()
                .WithMessage("Invalid username");

            RuleFor(r => r.Password).NotEmpty()
                .WithMessage("Invalid password");
        }
    }
}