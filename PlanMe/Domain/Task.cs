using System.Linq;

namespace PlanMe.Domain;

public class Task : PlanItem
{
    public Task(string id) : base(id)
    {
    }

    public Difficulty Difficulty { get; set; }

    public Priority Priority { get; set; }
    
    public PlanItem Parent { get; internal set; }

    public Project ParentProject => GetParentProject();

    public void MoveTo(TaskContainer container)
    {
        if (ReferenceEquals(Parent, container)) return;
        Parent.Remove(this);
        container.Add(this);
    }

    public void Complete()
    {
        if (Items.Count > 0) return;
        var set = StatusManager.Get(GetType());
        var complete = set.Items.FirstOrDefault(s => s.Type == StatusType.Complete);
        if (complete != null)
        {
            Status = complete;
        }
        
        CompleteParentStatus(Parent);
        Stop();
    }
    
    private Project GetParentProject()
    {
        return Parent switch
        {
            Project project => project,
            Task task => task.ParentProject,
            _ => null
        };
    }

    private void CompleteParentStatus(PlanItem parent)
    {
        if (parent == null || parent.Items.Any(t => t.Status.Type != StatusType.Complete)) return;
        var set = StatusManager.Get(parent.GetType());
        var complete = set.Items.FirstOrDefault(s => s.Type == StatusType.Complete);
        if (complete != null)
        {
            parent.Status = complete;
        }

        if (parent is Task parentTask)
        {
            CompleteParentStatus(parentTask.Parent);
        }
    }

    protected override void OnStart()
    {
        base.OnStart();
        Parent?.Start();
    }

    protected override void OnStop()
    {
        base.OnStop();
        Parent?.Stop();
    }
}