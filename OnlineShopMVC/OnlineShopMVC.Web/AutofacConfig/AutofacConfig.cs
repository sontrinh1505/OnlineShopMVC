using Autofac;
using Autofac.Integration.Mvc;
using Data;
using Data.Infrastructure;
using Data.Repositories;
using OnlineShopMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMVC.AutofacConfig
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API controllers.
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<OnlineShopMVCDbContext>().AsSelf().InstancePerRequest();

            //Asp.net Identity
            //builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            //builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            //builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            //builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            //builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

            //// Repositories
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            //// Services
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();


            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //Set the WebApi DependencyResolver
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);


            //builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            //builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();

        }
    }
}