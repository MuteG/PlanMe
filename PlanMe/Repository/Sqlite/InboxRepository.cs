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

    public void Remove(string taskId)
    {
        Execute(Sql("INBOX_DELETE"), new { TaskId = taskId });
    }

    public Inbox Get()
    {
        var inbox = Inbox.Instance;
        inbox.AddRange(Query<TaskModel>(Sql("INBOX_SELECT_ALL")).Select(m => m.ToTask()));
        return inbox;
    }
}