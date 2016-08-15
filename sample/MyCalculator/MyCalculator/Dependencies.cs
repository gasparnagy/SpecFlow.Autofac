using System;
using System.Linq;
using Autofac;

namespace MyCalculator
{
    public static class Dependencies
    {
        public static ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Calculator>().As<ICalculator>();

            return builder;
        }
    }
}
