using PlanMe.Services;

namespace PlanMe.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly PlanService _planService;

    public MainWindowViewModel()
    {
        _planService = new PlanService();
        var tasks = _planService.GetInboxTasks();
        Inbox = new InboxViewModel(tasks);
    }
    
    public string Greeting => "Welcome to Avalonia!";
    
    public InboxViewModel Inbox { get; }

    public void AddTask()
    {
        
    }
}