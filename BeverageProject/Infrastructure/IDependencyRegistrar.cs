using Autofac;

namespace BeverageProject.Infrastructure
{
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        void Register(ContainerBuilder builder);
    }
}