﻿using Autofac.Integration.WebApi;
using Autofac;
using Autofac.Core;

//using HomeCinema.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using TOCManager.DataLayer;
using TOCManager.DataLayer.Infrastructure;
using TOCManager.DataLayer.Repositories;
using TOCManager.Membership;

namespace TOCManager.WebApi.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // EF TOCManagerContext
            builder.RegisterType<TOCManagerContext>()
                   .As<DbContext>()
                   .InstancePerRequest();

            builder.RegisterType<DbFactory>()
                .As<IDbFactory>()
                .InstancePerRequest();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(EntityBaseRepository<>))
                .As(typeof(IEntityBaseRepository<>))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(ProjectsEntityBaseRepository<>))
                .As(typeof(IProjectsEntityBaseRepository<>))
                .InstancePerRequest();

            // Membership Services
            builder.RegisterType<EncryptionService>()
                .As<IEncryptionService>()
                .InstancePerRequest();

            builder.RegisterType<MembershipService>()
                .As<IMembershipService>()
                .InstancePerRequest();

            // Generic Data Repository Factory
            //builder.RegisterType<DataRepositoryFactory>()
            //    .As<IDataRepositoryFactory>().InstancePerRequest();

            Container = builder.Build();

            return Container;
        }
    }
}