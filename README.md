# SpecFlow.Autofac
SpecFlow plugin for using Autofac as a dependency injection framework for step definitions.

Currently supports
* SpecFlow v2.1
* Autofac v3.5.2 or above

License: Apache (https://github.com/gasparnagy/SpecFlow.Autofac/blob/master/LICENSE)

NuGet: https://www.nuget.org/packages/SpecFlow.Autofac

See my blog post (http://gasparnagy.com/2016/08/specflow-tips-customizing-dependency-injection-with-autofac/) for more information and background, you can also look at the complete example at https://github.com/gasparnagy/SpecFlow.Autofac/tree/master/sample/MyCalculator.

[![Build status](https://ci.appveyor.com/api/projects/status/oyxln9r52x9uamim/branch/master?svg=true)](https://ci.appveyor.com/project/gasparnagy/specflow-autofac/branch/master)

## Usage

Install plugin from NuGet into your SpecFlow project.

    PM> Install-Package SpecFlow.Autofac
  
Create a static method somewhere in the SpecFlow project (recommended to put it into the `Support` folder) that returns an Autofac `ContainerBuilder` and tag it with the `[ScenarioDependencies]` attribute. Configure your dependencies for the scenario execution within the method. You also have to register the step definition classes, that you can do by either registering all public types from the SpecFlow project:

    builder.RegisterAssemblyTypes(typeof(YourClassInTheSpecFlowProject).Assembly).SingleInstance();

or by registering all classes marked with the `[Binding]` attribute:

    builder.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();

A typical dependency builder method probably looks like this:

    [ScenarioDependencies]
    public static ContainerBuilder CreateContainerBuilder()
    {
      // create container with the runtime dependencies
      var builder = Dependencies.CreateContainerBuilder();

      //TODO: add customizations, stubs required for testing

      builder.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();
      
      return builder;
    }

## Release History

### v1.1.0

* Support SpecFlow v2.2.1 (thx to Zac Charles, @einsteine89)
* Allow the container to resolve ScenarioContext, FeatureContext, TestThreadContext, IObjectContainer (by @djmnz)

### v1.0.2

* Reduced the minimum Autofac version to 3.5.2 to target broader audience (PR#1 by @BlackstarSolar)

### v1.0.1

* Fix missing assembly from NuGet package (build order issue)

### v1.0.0

* Initial release based on the post: http://gasparnagy.com/2016/08/specflow-tips-customizing-dependency-injection-with-autofac/
