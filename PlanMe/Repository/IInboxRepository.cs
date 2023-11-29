using PlanMe.Domain;

namespace PlanMe.Repository;

public interface IInboxRepository : IPlanMeRepository
{
    void Save(Inbox inbox);

    void Remove(string taskId);

    Inbox Get();
}