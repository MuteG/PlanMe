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

    public static IReadOnlyList<StatusSet> Sets => _sets.Values.ToList();

    public static StatusSet Get<T>()
    {
        if (!_sets.ContainsKey(typeof(T)))
        {
            _sets.Add(typeof(T), new StatusSet());
        }

        return _sets[typeof(T)];
    }
}