using FluentValidation.Attributes;
using TOCManager.WebApi.Infrastructure.Validators;

namespace TOCManager.WebApi.Models
{
    [Validator(typeof(ProjectViewModelValidator))]
    public class ProjectViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}