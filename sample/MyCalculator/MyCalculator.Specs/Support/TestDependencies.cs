using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MyCalculator.Specs.StepDefinitions;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace MyCalculator.Specs.Support
{
    public static class TestDependencies
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            // create container with the runtime dependencies
            var builder = Dependencies.CreateContainerBuilder();

            //TODO: add customizations, stubs required for testing

            //builder.RegisterType<CalculatorSteps>();
            //builder.RegisterType<CalculatorSteps>().SingleInstance();
            //builder.RegisterAssemblyTypes(typeof(TestDependencies).Assembly).SingleInstance();
            builder.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();
             
            return builder;
        }
    }
}
