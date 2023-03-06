using Autofac;
using Autofac.Integration.Mvc;
using MyDatabase;
using System.Web.Http;
using System.Reflection;
using PersistenceLayerGeneric.IRepositories;
using PersistenceLayerGeneric.Repositories;
using Autofac.Integration.WebApi;

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
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerLifetimeScope();
            
            builder.RegisterType<MessageRepository>().As<IMessageRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ReplyRepository>().As<IReplyRepository>().InstancePerLifetimeScope();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}