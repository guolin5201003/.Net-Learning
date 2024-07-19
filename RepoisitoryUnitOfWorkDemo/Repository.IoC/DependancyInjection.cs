using Autofac;
using Microsoft.EntityFrameworkCore;
using Repository.Application;
using Repository.Domain.Models;
using Repository.Infrastucture;

namespace Repository.IoC
{
    public class DependancyInjection
    {
        private static IContainer container;

        static DependancyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EFCoreDBContext>().As<EFCoreDBContext>();
            builder.RegisterType<UnitOfWork>().As<UnitOfWork>();
            builder.RegisterType<GenericRepository<Customer>>().As<IRepository<Customer>>();
            builder.RegisterType<OrderService>();

            container = builder.Build();
        }

        public static T Resolve<T>() where T : class
        {
            return container.Resolve<T>();
        }

    }


}

