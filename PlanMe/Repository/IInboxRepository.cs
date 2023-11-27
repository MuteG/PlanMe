using PlanMe.Domain;

namespace PlanMe.Repository;

public interface IInboxRepository
{
    void Save(Inbox inbox);

    void Remove(string taskId);

    Inbox Get();
}