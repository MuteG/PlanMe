using System.Collections.Generic;
using System.Data;

namespace PlanMe.Repository;

public class TransactionManager
{
    private readonly DapperContext _context;
    private readonly List<IRepositoryTransaction> _repositories;
    private IDbTransaction _transaction;

    public TransactionManager(DapperContext context, params IRepositoryTransaction[] repositories)
    {
        _context = context;
        _repositories = new List<IRepositoryTransaction>(repositories);
    }

    public void Begin()
    {
        if (_transaction == null)
        {
            var conn = _context.CreateConnection();
            conn.Open();
            _transaction = conn.BeginTransaction();
            foreach (var repository in _repositories)
            {
                repository.Transaction = _transaction;
            }
        }
    }

    public void Commit()
    {
        if (_transaction != null)
        {
            _transaction.Commit();
            _transaction.Connection?.Close();
            _transaction.Dispose();
            _transaction = null;
            foreach (var repository in _repositories)
            {
                repository.Transaction = null;
            }
        }
    }
    
    public void Rollback()
    {
        if (_transaction != null)
        {
            _transaction.Rollback();
            _transaction.Connection?.Close();
            _transaction.Dispose();
            _transaction = null;
            foreach (var repository in _repositories)
            {
                repository.Transaction = null;
            }
        }
    }
}