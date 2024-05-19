using System.Collections.Generic;
using System.Linq;
using PlanMe.Domain;
using PlanMe.ViewModels;

namespace PlanMe.Services.EntityExtensions;

public static class TaskExtension
{
    private static readonly Dictionary<string, TaskModel> _modelCache = new();
    
    public static TaskModel ToModel(this Task task)
    {
        if (_modelCache.TryGetValue(task.Id, out var model))
        {
            return model;
        }
        
        model = new TaskModel
        {
            Id = task.Id,
            IsComplete = task.Status.Type == StatusType.Complete,
            Text = task.Name
        };
        _modelCache.Add(task.Id, model);
        return model;
    }

    public static List<TaskModel> ToModel(this IEnumerable<Task> tasks)
    {
        return tasks
            .OrderBy(i => i.Status.Type)
            .Select(t => t.ToModel())
            .ToList();
    }
}