using Avalonia.Media;

namespace PlanMe.Domain;

public class StatusSet : Container<Status>
{
    private static readonly StatusSet _default;

    static StatusSet()
    {
        _default = new StatusSet("SS000000000");
        _default.Add(new Status("S0000000001")
        {
            Color = Colors.Black,
            Name = "未着手",
            Type = StatusType.Waiting
        });
        _default.Add(new Status("S0000000002")
        {
            Color = Colors.CornflowerBlue,
            Name = "进行中",
            Type = StatusType.Process
        });
        _default.Add(new Status("S0000000003")
        {
            Color = Colors.LimeGreen,
            Name = "完成",
            Type = StatusType.Complete
        });
        _default.Add(new Status("S0000000004")
        {
            Color = Colors.DarkGray,
            Name = "取消",
            Type = StatusType.Invalid
        });
    }
    
    public StatusSet(string id)
    {
        Id = id;
    }

    public string Id { get; }
    
    public string Name { get; set; }
    
    public Status Add(string name, Color color, StatusType type)
    {
        var status = new Status(IdGenerator.New(Constant.Prefix.STATUS))
        {
            Name = name,
            Color = color,
            Type = type,
            Set = this
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

    public static StatusSet Default => _default;
}