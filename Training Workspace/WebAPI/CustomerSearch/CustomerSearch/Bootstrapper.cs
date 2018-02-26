using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using CustomerSearch.Repository;
using System.Web.Http;

namespace CustomerSearch
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));
      GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();
      container.RegisterType<ICustomerRepository,CustomerRepository>();
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}