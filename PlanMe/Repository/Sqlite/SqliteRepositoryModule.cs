using Autofac;

namespace PlanMe.Repository.Sqlite;

public class SqliteRepositoryModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<InboxRepository>().As<IInboxRepository>();
        builder.RegisterType<TaskRepository>().As<ITaskRepository>();
    }
}