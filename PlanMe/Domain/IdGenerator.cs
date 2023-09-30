using System.Collections.Generic;

namespace PlanMe.Domain;

public static class IdGenerator
{
    private static readonly Dictionary<string, int> _dictionary;

    static IdGenerator()
    {
        _dictionary = new Dictionary<string, int>();
    }

    public static void Initialize(string prefix, int currentId)
    {
        _dictionary[prefix] = currentId;
    }

    public static string New(string prefix)
    {
        _dictionary.TryAdd(prefix, 0);
        _dictionary[prefix]++;
        return Current(prefix);
    }

    private static string Current(string prefix)
    {
        _dictionary.TryAdd(prefix, 0);
        return $"{prefix}{_dictionary[prefix].ToString().PadLeft(10 - prefix.Length, '0')}";
    }
}