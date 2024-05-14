using System.Collections.Generic;

namespace PlanMe.Domain;

public class FourQuadrant
{
    private readonly List<Task> _importantAndUrgentTasks;
    
    private readonly List<Task> _importantButNotUrgentTasks;
    
    private readonly List<Task> _notImportantButUrgentTasks;
    
    private readonly List<Task> _notImportantAndNotUrgentTasks;

    public FourQuadrant()
    {
        _importantAndUrgentTasks = new List<Task>();
        _importantButNotUrgentTasks = new List<Task>();
        _notImportantButUrgentTasks = new List<Task>();
        _notImportantAndNotUrgentTasks = new List<Task>();
    }

    public IReadOnlyList<Task> ImportantAndUrgentTasks => _importantAndUrgentTasks;
    
    public IReadOnlyList<Task> ImportantButNotUrgentTasks => _importantButNotUrgentTasks;
    
    public IReadOnlyList<Task> NotImportantButUrgentTasks => _notImportantButUrgentTasks;
    
    public IReadOnlyList<Task> NotImportantAndNotUrgentTasks => _notImportantAndNotUrgentTasks;

    public void Sort(IEnumerable<Task> tasks)
    {
        _importantAndUrgentTasks.Clear();
        _importantButNotUrgentTasks.Clear();
        _notImportantButUrgentTasks.Clear();
        _notImportantAndNotUrgentTasks.Clear();
        foreach (var task in tasks)
        {
            if (task.Importance > Importance.Normal)
            {
                if (task.Priority > Priority.Normal)
                {
                    _importantAndUrgentTasks.Add(task);
                }
                else
                {
                    _importantButNotUrgentTasks.Add(task);
                }
            }
            else
            {
                if (task.Priority > Priority.Normal)
                {
                    _notImportantButUrgentTasks.Add(task);
                }
                else
                {
                    _notImportantAndNotUrgentTasks.Add(task);
                }
            }
        }
    }
}