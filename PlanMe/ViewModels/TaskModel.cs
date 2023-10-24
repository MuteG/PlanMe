namespace PlanMe.ViewModels;

public class TaskModel : ViewModelBase
{
    public bool IsComplete { get; set; }
    
    public string Text { get; set; }
}