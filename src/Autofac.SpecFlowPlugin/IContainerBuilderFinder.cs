using System;

namespace Autofac.SpecFlowPlugin
{
    public interface IContainerBuilderFinder
    {
        Func<ContainerBuilder> GetCreateScenarioContainerBuilder();
    }
}