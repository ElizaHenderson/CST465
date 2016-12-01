using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Lab4.Code.Repositories;
using Lab4.Code.DataObjects;
using System.Data.Entity;
using Lab4.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Lab4.Controllers;

namespace Lab4
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDataEntityRepository<BlogPost>, BlogDBRepository2>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IRoleStore<ApplicationRole, string>, RoleStore<ApplicationRole>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());
        }
    }
}