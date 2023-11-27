using PlanMe.Domain;

namespace PlanMe.Repository.Model;

public static class TaskExtension
{
    public static TaskModel ToModel(this Task task)
    {
        return new TaskModel
        {
            Id = task.Id,
            Name = task.Name,
            StatusId = task.Status.Id,
            StatusName = task.Status.Name,
            StatusColor = task.Status.Color.ToUInt32(),
            StatusType = (int)task.Status.Type,
            ExpectedStartDate = task.ExpectedStartDate,
            ExpectedCompleteDate = task.ExpectedCompleteDate,
            ExpectedWorkingTime = task.ExpectedWorkingTime.Ticks,
            ActualStartDate = task.ActualStartDate,
            ActualCompleteDate = task.ActualCompleteDate,
            ActualWorkingTime = task.ActualWorkingTime.Ticks,
            Difficulty = (int)task.Difficulty,
            Priority = (int)task.Priority
        };
    }
}