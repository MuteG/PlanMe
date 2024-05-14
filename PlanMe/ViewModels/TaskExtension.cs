using System.Collections.Generic;
using System.Linq;
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

    public static List<TaskModel> ToModel(this IEnumerable<Task> tasks)
    {
        return tasks
            .OrderBy(i => i.Status.Type)
            .Select(t => t.ToModel())
            .ToList();
    }
}