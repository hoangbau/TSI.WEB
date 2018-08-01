using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Reflection;
using System.Web.Mvc;
using TSI.DAL.DataContext;
using TSI.DAL.UnitOfWork;

namespace TSI.WEB.App_Start
{
    public class AutofacConfig
    {
        public static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            //Register Controller
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<TSIDataContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            //Register Repository
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            //Register Service
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}