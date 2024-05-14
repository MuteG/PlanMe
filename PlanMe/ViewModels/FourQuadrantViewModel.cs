namespace PlanMe.ViewModels;

public class FourQuadrantViewModel : ViewModelBase
{
    /// <summary>
    /// 重要且紧急
    /// </summary>
    public TaskListViewModel ImportantAndUrgentTasks { get; set; }

    /// <summary>
    /// 重要但不紧急
    /// </summary>
    public TaskListViewModel ImportantButNotUrgentTasks { get; set; }
    
    /// <summary>
    /// 不重要但紧急
    /// </summary>
    public TaskListViewModel NotImportantButUrgentTasks { get; set; }
    
    /// <summary>
    /// 不重要且不紧急
    /// </summary>
    public TaskListViewModel NotImportantAndNotUrgentTasks { get; set; }
}