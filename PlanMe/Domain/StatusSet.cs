using Avalonia.Media;

namespace PlanMe.Domain;

public class StatusSet : Container<Status>
{
    public StatusSet(string id)
    {
        Id = id;
    }

    public string Id { get; }
    
    public string Name { get; set; }
    
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