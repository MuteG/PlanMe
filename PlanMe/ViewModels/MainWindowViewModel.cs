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
    
    public InboxViewModel Inbox { get; }
}