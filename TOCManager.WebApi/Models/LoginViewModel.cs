using FluentValidation.Attributes;
using TOCManager.WebApi.Infrastructure.Validators;

namespace TOCManager.WebApi.Models
{
    [Validator(typeof(LoginViewModelValidator))]
    public class LoginViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}