using System.Collections.Generic;

namespace PlanMe.Domain;

public abstract class Container<T> where T : class
{
    private readonly List<T> _items;
    
    protected Container()
    {
        _items = new List<T>();
    }

    public IReadOnlyList<T> Items => _items;

    public bool Contains(T item)
    {
        return _items.Contains(item);
    }

    public void Add(T item)
    {
        if (Contains(item)) return;
        _items.Add(item);
        OnAdd(item);
    }

    protected virtual void OnAdd(T item)
    {
    }

    public void AddRange(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }

    public void Remove(T item)
    {
        if (!Contains(item)) return;
        _items.Remove(item);
        OnRemove(item);
    }

    protected virtual void OnRemove(T item)
    {
    }

    public void ChangeIndex(T item, int targetIndex)
    {
        if (!Contains(item) || _items.IndexOf(item) == targetIndex) return;
        if (_items.IndexOf(item) < targetIndex)
        {
            targetIndex--;
        }
        
        _items.Remove(item);
        _items.Insert(targetIndex, item);
    }
}