using FluentValidation.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TOCManager.WebApi.Mappings;

namespace TOCManager.WebApi.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            // Configure Autofac
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);

            //Configure AutoMapper
            AutoMapperConfiguration.Configure();

            // configure FluentValidation model validator provider
            FluentValidationModelValidatorProvider.Configure(GlobalConfiguration.Configuration);
        }
    }
}