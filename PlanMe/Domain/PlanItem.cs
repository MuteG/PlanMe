using System;
using System.Linq;

namespace PlanMe.Domain;

public abstract class PlanItem : TaskContainer
{
    private DateTime _workingStartTime;
    
    protected PlanItem(string id)
    {
        Id = id;
        ExpectedStartDate = DateTime.Today;
        ExpectedCompleteDate = DateTime.MaxValue;
        ExpectedWorkingTime = TimeSpan.MaxValue;
        ActualWorkingTime = TimeSpan.Zero;
        ActualStartDate = DateTime.UnixEpoch;
        ActualCompleteDate = DateTime.UnixEpoch;
        Status = StatusSet.Default.Items.First(s => s.Type == StatusType.Waiting);
    }
    
    public string Id { get; }

    public string Name { get; set; }

    public Status Status { get; set; }
    
    public DateTime ExpectedStartDate { get; set; }

    public DateTime ExpectedCompleteDate { get; set; }

    public TimeSpan ExpectedWorkingTime { get; set; }

    public DateTime ActualStartDate { get; set; }

    public DateTime ActualCompleteDate { get; set; }

    public TimeSpan ActualWorkingTime { get; set; }

    public bool IsDelay => DateTime.Today > ExpectedCompleteDate;
    
    public bool IsWorking => !DateTime.UnixEpoch.Equals(_workingStartTime);
    
    public void Start()
    {
        if(Items.Count > 0 || !DateTime.UnixEpoch.Equals(_workingStartTime)) return;
        _workingStartTime = DateTime.Now;
        if (DateTime.UnixEpoch.Equals(ActualStartDate))
        {
            ActualStartDate = DateTime.Today;
        }

        OnStart();
    }

    protected virtual void OnStart()
    {
    }

    public void Stop()
    {
        if (Items.Count > 0 || DateTime.UnixEpoch.Equals(_workingStartTime)) return;
        ActualWorkingTime += (DateTime.Now - _workingStartTime);
        _workingStartTime = DateTime.UnixEpoch;
        if (Status.Type == StatusType.Complete)
        {
            ActualCompleteDate = DateTime.Today;
        }

        OnStop();
    }

    protected virtual void OnStop()
    {
    }
    
    protected override void OnAdd(Task item)
    {
        base.OnAdd(item);
        item.Parent = this;
    }

    protected override void OnRemove(Task item)
    {
        base.OnRemove(item);
        item.Parent = null;
    }
}