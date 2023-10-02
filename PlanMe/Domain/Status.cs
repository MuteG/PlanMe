using Avalonia.Media;

namespace PlanMe.Domain;

public class Status
{
    public Status(string id)
    {
        Id = id;
    }

    public string Id { get; }
    
    public string Name { get; set; }
    
    public Color Color { get; set; }

    public StatusType Type { get; set; }
    
    public StatusSet Set { get; internal set; }
}