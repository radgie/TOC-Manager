using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOCManager.WebApi.Models;

namespace TOCManager.WebApi.Infrastructure.Validators
{
    public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(customer => customer.Name).NotEmpty().Length(1, 200).WithMessage("Name must be between 1 - 200 characters");

            RuleFor(customer => customer.Phone).Length(0, 15).WithMessage("Phone must have maximum 15 characters");

            RuleFor(customer => customer.Email).NotEmpty().Length(1, 200).WithMessage("Email address must be between 1 - 200 characters");
            RuleFor(customer => customer.Email).EmailAddress().WithMessage("Enter a valid Email address format");

            RuleFor(customer => customer.Address).NotEmpty().Length(1, 500).WithMessage("Address must be between 1 - 500 characters");

            RuleFor(customer => customer.Description).Length(0, 4000).WithMessage("Description must have maximum 4000 characters");
        }
    }
}