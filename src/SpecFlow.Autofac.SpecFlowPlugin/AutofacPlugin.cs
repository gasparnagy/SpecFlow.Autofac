using System;
using System.Diagnostics;
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
                // temporary fix for CustomizeGlobalDependencies called multiple times
                // see https://github.com/techtalk/SpecFlow/issues/948
                if (!args.ObjectContainer.IsRegistered<IContainerBuilderFinder>())
                {
                    args.ObjectContainer.RegisterTypeAs<AutofacTestObjectResolver, ITestObjectResolver>();
                    args.ObjectContainer.RegisterTypeAs<ContainerBuilderFinder, IContainerBuilderFinder>();

                    // workaround for parallel execution issue - this should be rather a feature in BoDi?
                    args.ObjectContainer.Resolve<IContainerBuilderFinder>();
                }
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
