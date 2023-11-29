using PlanMe.Domain;
using PlanMe.Repository.Model;

namespace PlanMe.Repository.Sqlite;

public class TaskRepository : SqliteRepository, ITaskRepository
{
    public void Add(Task task)
    {
        Execute(Sql("TASK_INSERT"), task.ToModel());
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