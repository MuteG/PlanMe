using System.Collections.Generic;
using ReactiveUI;

namespace PlanMe.ViewModels;

public class InboxViewModel : ViewModelBase
{
    private TaskListViewModel _taskList;

    public InboxViewModel(IReadOnlyList<TaskModel> inboxTasks)
    {
        TaskList = new TaskListViewModel(inboxTasks);
    }

    public TaskListViewModel TaskList
    {
        get => _taskList;
        set
        { 
            _taskList = value;
            this.RaisePropertyChanged();
        }
    }
}