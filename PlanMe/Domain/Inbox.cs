namespace PlanMe.Domain;

public class Inbox : TaskContainer
{
    private static readonly Inbox _instance;

    static Inbox()
    {
        _instance = new Inbox();
    }

    public static Inbox Instance => _instance;
}