using System.Linq;
using PlanMe.Domain;
using PlanMe.Repository.Model;

namespace PlanMe.Repository.Sqlite;

public class InboxRepository : SqliteRepository, IInboxRepository
{
    public InboxRepository(DapperContext context) : base(context)
    {
    }

    public void Save(Inbox inbox)
    {
        Execute(Sql("INBOX_INSERT_OR_IGNORE"), inbox.Items.Select(i => i.Id).ToList());
    }

    public void Remove(string taskId)
    {
        Execute(Sql("INBOX_DELETE"), new { taskId });
    }

    public Inbox Get()
    {
        var inbox = new Inbox();
        inbox.AddRange(Query<TaskModel>(Sql("INBOX_SELECT_ALL")).Select(m => m.ToTask()));
        return inbox;
    }
}