namespace PlanMe.Domain;

public class Inbox : TaskContainer
{
    private static readonly Inbox _instance;

    static Inbox()
    {
        _instance = new Inbox();
        _instance.Add("Test1");
        _instance.Add("Test2");
    }

    public static Inbox Instance => _instance;
}