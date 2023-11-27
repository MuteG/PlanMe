using System;
using Avalonia.Media;
using PlanMe.Domain;

namespace PlanMe.Repository.Model;

public class TaskModel
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string StatusId { get; set; }
    
    public string StatusName { get; set; }

    public uint StatusColor { get; set; }

    public int StatusType { get; set; }

    public DateTime ExpectedStartDate { get; set; }

    public DateTime ExpectedCompleteDate { get; set; }

    public long ExpectedWorkingTime { get; set; }

    public DateTime ActualStartDate { get; set; }

    public DateTime ActualCompleteDate { get; set; }

    public long ActualWorkingTime { get; set; }
    
    public int Difficulty { get; set; }

    public int Priority { get; set; }

    public Task ToTask()
    {
        return new Task(Id)
        {
            Name = Name,
            Status = new Status(StatusId)
            {
                Name = StatusName,
                Color = Color.FromUInt32(StatusColor),
                Type = (StatusType)StatusType
            },
            ExpectedStartDate = ExpectedStartDate,
            ExpectedCompleteDate = ExpectedCompleteDate,
            ExpectedWorkingTime = TimeSpan.FromTicks(ExpectedWorkingTime),
            ActualStartDate = ActualStartDate,
            ActualCompleteDate = ActualCompleteDate,
            ActualWorkingTime = TimeSpan.FromTicks(ActualWorkingTime),
            Difficulty = (Difficulty)Difficulty,
            Priority = (Priority)Priority
        };
    }
}