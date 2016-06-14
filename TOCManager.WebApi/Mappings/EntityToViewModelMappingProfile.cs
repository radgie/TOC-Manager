using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOCManager.Entities;
using TOCManager.WebApi.Models;

namespace TOCManager.WebApi.Mappings
{
    public class EntityToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Customer, CustomerViewModel>();
        }
    }
}