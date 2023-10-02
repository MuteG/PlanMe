namespace PlanMe.Domain;

public abstract class TaskContainer : Container<Task>
{
    public Task Add(string name)
    {
        var task = new Task(IdGenerator.New("T"))
        {
            Name = name
        };
        Add(task);
        return task;
    }
}