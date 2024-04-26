using System.Collections.Generic;
using ReactiveUI;

namespace PlanMe.ViewModels;

public class InboxViewModel : ViewModelBase
{
    private IReadOnlyList<TaskModel> _inboxTasks;

    public InboxViewModel(IReadOnlyList<TaskModel> inboxTasks)
    {
        InboxTasks = inboxTasks;
        IncludeCompleted = true;
    }

    public IReadOnlyList<TaskModel> InboxTasks
    {
        get => _inboxTasks;
        set
        { 
            _inboxTasks = value;
            this.RaisePropertyChanged();
        }
    }

    public bool IncludeCompleted { get; set; }
}