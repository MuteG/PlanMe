using System.Linq;
using PlanMe.Domain;

namespace PlanMe.Repository.Model;

public static class InboxExtension
{
    public static InboxModel ToModel(this Inbox inbox)
    {
        return new InboxModel
        {
            Tasks = inbox.Items.Select(i => i.ToModel()).ToList()
        };
    }
}