using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Lab4.Code.Repositories;
using Lab4.Code.DataObjects;

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
        }
    }
}