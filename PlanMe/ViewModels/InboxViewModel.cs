using System.Collections.Generic;

namespace PlanMe.ViewModels;

public class InboxViewModel : ViewModelBase
{
    public InboxViewModel(IReadOnlyList<TaskModel> inboxTasks)
    {
        InboxTasks = inboxTasks;
    }

    public IReadOnlyList<TaskModel> InboxTasks { get; }
}