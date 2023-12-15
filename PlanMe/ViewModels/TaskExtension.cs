using PlanMe.Domain;

namespace PlanMe.ViewModels;

public static class TaskExtension
{
    public static TaskModel ToModel(this Task task)
    {
        return new TaskModel
        {
            Id = task.Id,
            IsComplete = task.Status.Type == StatusType.Complete,
            Text = task.Name
        };
    }
}