using System.Web.Mvc;
using LRDNUG.Web.Models;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace LRDNUG.Web
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<IMeetingRepository, MeetingRepository>();
        container.RegisterType<ILocationRepository, LocationRepository>();
        container.RegisterType<ISponsorsRepository, SponsorsRepository>();
    }
  }
}