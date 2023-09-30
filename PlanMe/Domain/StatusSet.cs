using System.Collections.Generic;
using Avalonia.Media;

namespace PlanMe.Domain;

public class StatusSet
{
    private readonly List<Status> _statuses;

    public StatusSet()
    {
        _statuses = new List<Status>();
    }

    public Status Add(string name, Color color)
    {
        var status = new Status(IdGenerator.New("S"))
        {
            Name = name,
            Color = color
        };
        Add(status);
        return status;
    }

    public void Add(Status status)
    {
        if (_statuses.Contains(status)) return;
        _statuses.Add(status);
    }

    public void AddRange(IEnumerable<Status> statuses)
    {
        foreach (var status in statuses)
        {
            Add(status);
        }
    }

    public void Remove(Status status)
    {
        if (!_statuses.Contains(status)) return;
        _statuses.Remove(status);
    }
    
    public void ChangeIndex(Status status, int targetIndex)
    {
        if (!_statuses.Contains(status) || _statuses.IndexOf(status) == targetIndex) return;
        if (_statuses.IndexOf(status) < targetIndex)
        {
            targetIndex--;
        }
        
        _statuses.Remove(status);
        _statuses.Insert(targetIndex, status);
    }
}