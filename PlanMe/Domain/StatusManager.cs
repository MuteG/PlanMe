using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanMe.Domain;

public static class StatusManager
{
    private static readonly Dictionary<Type, StatusSet> _sets;

    static StatusManager()
    {
        _sets = new Dictionary<Type, StatusSet>();
    }
    
    // TODO 既存状态集初始化

    public static IReadOnlyList<StatusSet> Sets => _sets.Values.ToList();

    public static StatusSet Get<T>() where T : PlanItem
    {
        return Get(typeof(T));
    }
    
    public static StatusSet Get(Type type)
    {
        _sets.TryAdd(type, StatusSet.Default);
        return _sets[type];
    }

    public static StatusSet NewSet(Type type)
    {
        _sets[type] = new StatusSet(IdGenerator.New(Constant.Prefix.STATUS_SET));
        return _sets[type];
    }
}