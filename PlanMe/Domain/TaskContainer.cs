using System.Collections.Generic;

namespace PlanMe.Domain;

public abstract class TaskContainer
{
    private readonly List<Task> _tasks;
    
    protected TaskContainer()
    {
        _tasks = new List<Task>();
    }

    public IReadOnlyList<Task> Tasks => _tasks;

    public Task AddTask(string name)
    {
        var task = new Task(IdGenerator.New("T"))
        {
            Name = name
        };
        AddTask(task);
        return task;
    }

    public void AddTask(Task task)
    {
        _tasks.Add(task);
        task.Parent = this;
    }

    public void AddTasks(IEnumerable<Task> tasks)
    {
        foreach (var task in tasks)
        {
            AddTask(task);
        }
    }

    public void Remove(Task task)
    {
        if (!_tasks.Contains(task)) return;
        _tasks.Remove(task);
        task.Parent = null;
    }

    public void MoveTask(Task task, TaskContainer target)
    {
        _tasks.Remove(task);
        target.AddTask(task);
    }

    public void ChangeIndex(Task task, int targetIndex)
    {
        if (!_tasks.Contains(task) || _tasks.IndexOf(task) == targetIndex) return;
        if (_tasks.IndexOf(task) < targetIndex)
        {
            targetIndex--;
        }
        
        _tasks.Remove(task);
        _tasks.Insert(targetIndex, task);
    }
}