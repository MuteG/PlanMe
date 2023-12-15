using System.Collections.Generic;
using PlanMe.Services;
using ReactiveUI;

namespace PlanMe.ViewModels;

public class InboxViewModel : ViewModelBase
{
    private readonly PlanService _planService;
    private IReadOnlyList<TaskModel> _inboxTasks;

    public InboxViewModel(IReadOnlyList<TaskModel> inboxTasks)
    {
        _planService = new PlanService();
        InboxTasks = inboxTasks;
    }

    public IReadOnlyList<TaskModel> InboxTasks
    {
        get => _inboxTasks;
        private set
        { 
            _inboxTasks = value;
            foreach (var task in _inboxTasks)
            {
                task.Inbox = this;
            }
        }
    }

    public void AddTask(string name)
    {
        _planService.AddInboxTask(name);
        RefreshTasks();
    }

    public void RemoveTask(string taskId)
    {
        _planService.RemoveTask(taskId);
        RefreshTasks();
    }

    public void RefreshTasks()
    {
        InboxTasks = _planService.GetInboxTasks();
        this.RaisePropertyChanged(nameof(InboxTasks));
    }
}