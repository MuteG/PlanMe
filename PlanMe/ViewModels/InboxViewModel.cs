using System.Collections.Generic;
using PlanMe.Services;
using ReactiveUI;

namespace PlanMe.ViewModels;

public class InboxViewModel : ViewModelBase
{
    private readonly PlanService _planService;
    
    public InboxViewModel(IReadOnlyList<TaskModel> inboxTasks)
    {
        _planService = new PlanService();
        InboxTasks = inboxTasks;
    }

    public IReadOnlyList<TaskModel> InboxTasks { get; private set; }

    public void AddTask(string name)
    {
        _planService.AddInboxTask(name);
        InboxTasks = _planService.GetInboxTasks();
        this.RaisePropertyChanged(nameof(InboxTasks));
    }
}