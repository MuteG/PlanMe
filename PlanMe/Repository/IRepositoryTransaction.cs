using System.Data;

namespace PlanMe.Repository;

public interface IRepositoryTransaction
{
    IDbTransaction Transaction { get; set; }
}