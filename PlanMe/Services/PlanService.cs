using System.Collections.Generic;
using System.Linq;
using PlanMe.Domain;
using PlanMe.Repository;
using PlanMe.ViewModels;

namespace PlanMe.Services;

public class PlanService
{
    public IReadOnlyList<TaskModel> GetInboxTasks()
    {
        if (Inbox.Instance.Items.Count == 0)
        {
            var repo = RepositoryFactory.Create<IInboxRepository>();
            repo.Get();
        }
        
        return Inbox.Instance.Items.Select(i => i.ToModel()).ToList();
    }

    public void AddInboxTask(string name)
    {
        var task = Inbox.Instance.Add(name);
        var inboxRepo = RepositoryFactory.Create<IInboxRepository>();
        var taskRepo = RepositoryFactory.Create<ITaskRepository>();
        var tran = new TransactionManager(DapperContext.Sqlite, inboxRepo, taskRepo);
        tran.Begin();
        inboxRepo.Save(Inbox.Instance);
        taskRepo.Add(task);
        tran.Commit();
    }
}