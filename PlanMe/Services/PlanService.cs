using System.Collections.Generic;
using System.Linq;
using PlanMe.Domain;
using PlanMe.Repository;
using PlanMe.ViewModels;

namespace PlanMe.Services;

public class PlanService
{
    public IReadOnlyList<TaskModel> GetInboxTaskModels(bool includeCompleted)
    {
        return GetInboxTaskEntities(includeCompleted).ToModel();
    }

    public FourQuadrantViewModel GetInboxFourQuadrantViewModel(bool includeCompleted)
    {
        var tasks = GetInboxTaskEntities(includeCompleted);
        var fourQuadrant = new FourQuadrant();
        fourQuadrant.Sort(tasks);
        return fourQuadrant.ToModel();
    }
    
    public void AddInboxTask(string name)
    {
        var task = Inbox.Instance.AddTask(name);
        var inboxRepo = RepositoryFactory.Create<IInboxRepository>();
        var taskRepo = RepositoryFactory.Create<ITaskRepository>();
        var tran = new TransactionManager(DapperContext.Sqlite, inboxRepo, taskRepo);
        tran.Begin();
        inboxRepo.Save(Inbox.Instance);
        taskRepo.Add(task);
        tran.Commit();
    }

    public void RemoveTask(string id)
    {
        // TODO 根据Task所属删除Task
        var task = Inbox.Instance.RemoveTask(id);
        if (task != null)
        {
            var inboxRepo = RepositoryFactory.Create<IInboxRepository>();
            var taskRepo = RepositoryFactory.Create<ITaskRepository>();
            var tran = new TransactionManager(DapperContext.Sqlite, inboxRepo, taskRepo);
            tran.Begin();
            inboxRepo.RemoveTask(id);
            taskRepo.Remove(task);
            tran.Commit();
        }
    }

    public void CompleteTask(string id)
    {
        var task = Inbox.Instance.Items.FirstOrDefault(i => i.Id == id);
        if (task != null)
        {
            task.Complete();
            var taskRepo = RepositoryFactory.Create<ITaskRepository>();
            taskRepo.Set(task);
        }
    }
    
    public void ResumeTask(string id)
    {
        var task = Inbox.Instance.Items.FirstOrDefault(i => i.Id == id);
        if (task != null)
        {
            task.Resume();
            var taskRepo = RepositoryFactory.Create<ITaskRepository>();
            taskRepo.Set(task);
        }
    }

    private List<Task> GetInboxTaskEntities(bool includeCompleted)
    {
        if (Inbox.Instance.Items.Count == 0)
        {
            var repo = RepositoryFactory.Create<IInboxRepository>();
            var tasks = repo.GetTasks();
            Inbox.Instance.AddRange(tasks);
            var maxTaskId = tasks.MaxBy(i => i.Id)?.Id ?? $"{Constant.Prefix.TASK}0";
            var currentId = int.Parse(maxTaskId.TrimStart(Constant.Prefix.TASK.ToArray()));
            IdGenerator.Initialize(Constant.Prefix.TASK, currentId);
        }

        return Inbox.Instance.Items
            .Where(i => includeCompleted || i.IsWorking)
            .ToList();
    }
}