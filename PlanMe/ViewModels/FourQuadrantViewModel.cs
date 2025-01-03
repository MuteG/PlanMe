namespace PlanMe.ViewModels;

public class FourQuadrantViewModel : ViewModelBase
{
    /// <summary>
    /// 重要且紧急
    /// </summary>
    public TitledTaskListViewModel ImportantAndUrgentTasks { get; set; }

    /// <summary>
    /// 重要但不紧急
    /// </summary>
    public TitledTaskListViewModel ImportantButNotUrgentTasks { get; set; }
    
    /// <summary>
    /// 不重要但紧急
    /// </summary>
    public TitledTaskListViewModel NotImportantButUrgentTasks { get; set; }
    
    /// <summary>
    /// 不重要且不紧急
    /// </summary>
    public TitledTaskListViewModel NotImportantAndNotUrgentTasks { get; set; }
}