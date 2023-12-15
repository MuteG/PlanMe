using Avalonia.Media;
using PlanMe.Services;
using ReactiveUI;

namespace PlanMe.ViewModels;

public class TaskModel : ViewModelBase
{
    private readonly PlanService _planService;
    private bool _isComplete;

    public TaskModel()
    {
        _planService = new PlanService();
    }

    public string Id { get; set; }

    public bool IsComplete
    {
        get => _isComplete;
        set
        {
            if (_isComplete ^ value)
            {
                _isComplete = value;
                if (_isComplete)
                {
                    _planService.CompleteTask(Id);
                }
                else
                {
                    _planService.ResumeTask(Id);
                }
                
                this.RaisePropertyChanged(nameof(Foreground));
                Inbox?.RefreshTasks();
            }
        }
    }

    public IBrush Foreground => IsComplete ? Brushes.DarkGray : Brushes.Black;
    
    public string Text { get; set; }
    
    public InboxViewModel Inbox { get; internal set; }

    public void Delete()
    {
        Inbox?.RemoveTask(Id);
    }
}