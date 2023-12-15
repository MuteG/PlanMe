using System;
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
        if (TrySetStatus(StatusType.Complete))
        {
            Stop();
            SetParentStatus(Parent, StatusType.Complete);
        }
    }

    public void Resume()
    {
        if (TrySetStatus(StatusType.Waiting))
        {
            SetParentStatus(Parent, StatusType.Waiting);
        }
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

    private void SetParentStatus(PlanItem parent, StatusType type)
    {
        if (parent == null || parent.Items.Any(t => t.Status.Type != type)) return;
        if (parent.TrySetStatus(type))
        {
            if (parent is Task parentTask)
            {
                SetParentStatus(parentTask.Parent, type);
            }
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