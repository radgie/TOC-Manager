using System;
using TOCManager.Entities;
using TOCManager.WebApi.Models;

namespace TOCManager.WebApi.Infrastructure.Extensions
{
    public static class EntitiesExtensions
    {
        public static void UpdateCustomer(this Customer customer, CustomerViewModel customerVm)
        {
            customer.ProjectId = customerVm.ProjectId;
            customer.Name = customerVm.Name;
            customer.Phone = customerVm.Phone;
            customer.Email = customerVm.Email;
            customer.Address = customerVm.Address;
            customer.Description = customerVm.Description;
        }

        public static void UpdateProject(this Project customer, ProjectViewModel projectVm)
        {
            customer.Name = projectVm.Name;
        }
    }
}