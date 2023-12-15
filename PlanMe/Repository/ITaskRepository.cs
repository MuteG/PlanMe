using PlanMe.Domain;

namespace PlanMe.Repository;

public interface ITaskRepository : IPlanMeRepository
{
    void Add(Task task);

    void Remove(Task task);

    void Set(Task task);

    Task Get(string id);
}