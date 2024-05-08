using System.Collections.Generic;
using System.Linq;
using ReactiveUI;

namespace PlanMe.ViewModels;

public class TaskListViewModel : ViewModelBase
{
    private IReadOnlyList<TaskModel> _tasks;

    public TaskListViewModel(IEnumerable<TaskModel> tasks)
    {
        Tasks = tasks.ToList();
        IncludeCompleted = true;
    }

    public IReadOnlyList<TaskModel> Tasks
    {
        get => _tasks;
        set
        { 
            _tasks = value;
            this.RaisePropertyChanged();
        }
    }

    public bool IncludeCompleted { get; set; }
}