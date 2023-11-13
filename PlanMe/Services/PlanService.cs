using System.Collections.Generic;
using System.Linq;
using PlanMe.Domain;
using PlanMe.ViewModels;

namespace PlanMe.Services;

public class PlanService
{
    public IReadOnlyList<TaskModel> GetInboxTasks()
    {
        return Inbox.Instance.Items.Select(i => new TaskModel{Text = i.Name}).ToList();
    }

    public void AddInboxTask(string name)
    {
        Inbox.Instance.Add(name);
    }
}