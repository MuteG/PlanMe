using PlanMe.Domain;
using PlanMe.Repository.Model;

namespace PlanMe.Repository.Sqlite;

public class TaskRepository : SqliteRepository, ITaskRepository
{
    public TaskRepository(DapperContext context) : base(context)
    {
    }

    public void Add(Task task)
    {
        Execute(Sql("TASK_INSERT"), task);
    }

    public void Remove(Task task)
    {
        Execute(Sql("TASK_DELETE"), new { task.Id });
    }

    public Task Get(string id)
    {
        return QuerySingle<TaskModel>(Sql("TASK_SELECT_BY_ID"), new { id }).ToTask();
    }
}