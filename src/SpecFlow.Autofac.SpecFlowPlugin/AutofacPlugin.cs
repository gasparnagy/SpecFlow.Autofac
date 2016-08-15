using System;
using System.Linq;
using Autofac;
using SpecFlow.Autofac;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;

[assembly: RuntimePlugin(typeof(AutofacPlugin))]

namespace SpecFlow.Autofac
{
    public class AutofacPlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
        {
            runtimePluginEvents.CustomizeGlobalDependencies += (sender, args) =>
            {
                args.ObjectContainer.RegisterTypeAs<AutofacBindingInstanceResolver, IBindingInstanceResolver>();
                args.ObjectContainer.RegisterTypeAs<ContainerBuilderFinder, IContainerBuilderFinder>();
            };

            runtimePluginEvents.CustomizeScenarioDependencies += (sender, args) =>
            {
                args.ObjectContainer.RegisterFactoryAs<IComponentContext>(() =>
                {
                    var containerBuilderFinder = args.ObjectContainer.Resolve<IContainerBuilderFinder>();
                    var createScenarioContainerBuilder = containerBuilderFinder.GetCreateScenarioContainerBuilder();
                    var containerBuilder = createScenarioContainerBuilder();
                    var container = containerBuilder.Build();
                    return container.BeginLifetimeScope();
                });
            };
        }
    }
}
