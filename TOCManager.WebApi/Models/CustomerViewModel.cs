using FluentValidation.Attributes;
using TOCManager.WebApi.Infrastructure.Validators;

namespace TOCManager.WebApi.Models
{
    [Validator(typeof(CustomerViewModelValidator))]
    public class CustomerViewModel
    {
        public int ID { get; set; }

        public int ProjectId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }
    }
}