using System;

namespace PlanMe.Domain;

public class Task : TaskContainer
{
    public Task(string id)
    {
        Id = id;
    }
    
    public string Id { get; }

    public string Name { get; set; }

    public Difficulty Difficulty { get; set; }

    public Priority Priority { get; set; }

    public Status Status { get; set; }

    public DateTime ExpectedStartDate { get; set; }

    public DateTime ExpectedCompleteDate { get; set; }

    public TimeSpan ExpectedWorkingTime { get; set; }

    public DateTime ActualStartDate { get; set; }

    public DateTime ActualCompleteDate { get; set; }

    public TimeSpan ActualWorkingTime { get; set; }
    
    public TaskContainer Parent { get; internal set; }

    public Project ParentProject => GetParentProject();

    private Project GetParentProject()
    {
        return Parent switch
        {
            Project project => project,
            Task task => task.ParentProject,
            _ => null
        };
    }
}