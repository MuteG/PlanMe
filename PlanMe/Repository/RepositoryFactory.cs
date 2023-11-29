using Autofac;

namespace PlanMe.Repository;

public static class RepositoryFactory
{
    private static IContainer _container;
    
    public static void RegisterModule(Module module)
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule(module);
        _container = builder.Build();
    }
    
    public static TRepo Create<TRepo>() where TRepo : IPlanMeRepository
    {
        return _container.Resolve<TRepo>();
    }
}