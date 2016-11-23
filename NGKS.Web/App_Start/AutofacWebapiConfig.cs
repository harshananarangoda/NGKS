using Autofac;
using Autofac.Integration.WebApi;
using NGKS.Data;
using NGKS.Data.Infrastructure;
using NGKS.Data.Repositories;
using NGKS.Services;
using NGKS.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace NGKS.Web.App_Start
{
    /// <summary>
    /// Class: AutofacWebapiConfig
    /// </summary>
    public class AutofacWebapiConfig
    {
        /// <summary>
        /// Autofac Container
        /// </summary>
        public static IContainer Container;
        /// <summary>
        /// Initialize the Autofac
        /// </summary>
        /// <param name="config">HttpConfiguration</param>
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        /// <summary>
        /// Initialize the Configuration and autofac Container
        /// </summary>
        /// <param name="config">HttpConfiguration</param>
        /// <param name="container">IContainer</param>
        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        /// <summary>
        /// Regiester Services
        /// </summary>
        /// <param name="builder">Autofac Builder</param>
        /// <returns>IContainer</returns>
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            // EF HomeCinemaContext
            builder.RegisterType<NGKSContext>()
                   .As<DbContext>()
                   .InstancePerRequest();

            builder.RegisterType<DbFactory>()
                .As<IDbFactory>()
                .InstancePerRequest();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(EntityRepository<>))
                   .As(typeof(IEntityRepository<>))
                   .InstancePerRequest();

            // Services
            builder.RegisterType<EncryptionService>()
                .As<IEncryptionService>()
                .InstancePerRequest();

            builder.RegisterType<MembershipService>()
                .As<IMembershipService>()
                .InstancePerRequest();

            Container = builder.Build();

            return Container;
        }
    }
}