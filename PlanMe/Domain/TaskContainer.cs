using System.Linq;

namespace PlanMe.Domain;

public abstract class TaskContainer : Container<Task>
{
    public Task Add(string name)
    {
        var task = new Task(IdGenerator.New(Constant.Prefix.TASK))
        {
            Name = name
        };
        Add(task);
        return task;
    }

    public Task Remove(string id)
    {
        var task = Items.FirstOrDefault(i => i.Id == id);
        if (task != null)
        {
            Remove(task);
            return task;
        }

        return null;
    }
}