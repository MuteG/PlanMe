using Avalonia.Media;

namespace PlanMe.Domain;

public class StatusSet : Container<Status>
{
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
    
    protected override void OnAdd(Status item)
    {
        base.OnAdd(item);
        item.Set = this;
    }

    protected override void OnRemove(Status item)
    {
        base.OnRemove(item);
        item.Set = null;
    }
}