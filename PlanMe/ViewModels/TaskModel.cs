using Avalonia.Media;
using ReactiveUI;

namespace PlanMe.ViewModels;

public class TaskModel : ViewModelBase
{
    private bool _isComplete;

    public string Id { get; set; }

    public bool IsComplete
    {
        get => _isComplete;
        set
        {
            if (_isComplete ^ value)
            {
                _isComplete = value;
                this.RaisePropertyChanged(nameof(Foreground));
            }
        }
    }

    public IBrush Foreground => IsComplete ? Brushes.DarkGray : Brushes.Black;
    
    public string Text { get; set; }
}