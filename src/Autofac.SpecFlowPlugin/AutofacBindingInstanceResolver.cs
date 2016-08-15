using System;
using System.Linq;
using BoDi;
using TechTalk.SpecFlow.Infrastructure;

namespace Autofac.SpecFlowPlugin
{
    public class AutofacBindingInstanceResolver : IBindingInstanceResolver
    {
        public object ResolveBindingInstance(Type bindingType, IObjectContainer scenarioContainer)
        {
            var componentContext = scenarioContainer.Resolve<IComponentContext>();
            return componentContext.Resolve(bindingType);
        }
    }
}
