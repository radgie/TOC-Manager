using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOCManager.WebApi.Models;

namespace TOCManager.WebApi.Infrastructure.Validators
{
    public class ProjectViewModelValidator : AbstractValidator<ProjectViewModel>
    {
        public ProjectViewModelValidator()
        {
            RuleFor(project => project.Name).NotEmpty().Length(1, 200).WithMessage("Name must be between 1 - 200 characters");
        }
    }
}