using Autofac;
using Autofac.Integration.Mvc;
using MyDatabase;
using System.Web.Http;
using System.Reflection;

namespace BeverageProject.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public DependencyRegistrar(ContainerBuilder builder)
        {
            Register(builder);
        }
        public void Register(ContainerBuilder builder)
        {
            var config = GlobalConfiguration.Configuration;
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();

            builder.RegisterType<ApplicationDbContext>().InstancePerLifetimeScope();

        }
    }
}