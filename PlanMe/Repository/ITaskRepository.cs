using PlanMe.Domain;

namespace PlanMe.Repository;

public interface ITaskRepository
{
    void Add(Task task);

    void Remove(Task task);

    Task Get(string id);
}