using FluentValidation.Attributes;
using TOCManager.WebApi.Infrastructure.Validators;

namespace TOCManager.WebApi.Models
{
    [Validator(typeof(RegistrationViewModelValidator))]
    public class RegistrationViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}