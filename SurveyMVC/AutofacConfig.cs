using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyMVC.Abstract;
using SurveyMVC.Implementation;
using SurveyMVC;

namespace WebDipInj
{
  public class AutofacConfig
  {
    public static void ConfigureContainer()
    {

      var builder = new ContainerBuilder();
      object p = builder.RegisterControllers(typeof(MvcApplication).Assembly);
      builder.RegisterType<ServiceDapperUser>().As<IUser>();
      builder.RegisterType<ServiceDapperResult>().As<IResult>();
      var container = builder.Build();
      DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
  }
}