using System.Collections.Generic;
using System.Linq;
using PlanMe.Domain;
using PlanMe.Repository.Model;

namespace PlanMe.Repository.Sqlite;

public class InboxRepository : SqliteRepository, IInboxRepository
{
    public void Save(Inbox inbox)
    {
        foreach (var task in inbox.Items)
        {
            Execute(Sql("INBOX_INSERT_OR_IGNORE"), new { TaskId = task.Id });
        }
    }

    public void RemoveTask(string taskId)
    {
        Execute(Sql("INBOX_DELETE"), new { TaskId = taskId });
    }

    public List<Task> GetTasks()
    {
        return Query<TaskModel>(Sql("INBOX_SELECT_ALL"))
            .Select(m => m.ToTask())
            .ToList();
    }
}