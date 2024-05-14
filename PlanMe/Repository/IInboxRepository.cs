using System.Collections.Generic;
using PlanMe.Domain;

namespace PlanMe.Repository;

public interface IInboxRepository : IPlanMeRepository
{
    void Save(Inbox inbox);

    void RemoveTask(string taskId);

    List<Task> GetTasks();
}