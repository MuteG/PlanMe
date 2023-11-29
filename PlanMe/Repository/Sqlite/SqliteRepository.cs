using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Avalonia.Platform;
using Dapper;

namespace PlanMe.Repository.Sqlite;

public abstract class SqliteRepository : IRepositoryTransaction
{
    private readonly DapperContext _context;
    private IDbTransaction _transaction;

    protected SqliteRepository()
    {
        _context = DapperContext.Sqlite;
    }

    IDbTransaction IRepositoryTransaction.Transaction
    {
        get => _transaction;
        set => _transaction = value;
    }

    protected string Sql(string name)
    {
        var resource = $"avares://PlanMe/Resources/Sql/{name}";
        using var stream = AssetLoader.Open(new Uri(resource));
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
    
    protected IEnumerable<T> Query<T>(string sql, object param = null)
    {
        if (_transaction?.Connection == null)
        {
            using var conn = _context.CreateConnection();
            return conn.Query<T>(sql, param);
        }
        else
        {
            return _transaction.Connection.Query<T>(sql, param, _transaction);
        }
    }
    
    protected IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql,
        Func<TFirst, TSecond, TReturn> map, string splitOn, object param = null)
    {
        if (_transaction?.Connection == null)
        {
            using var conn = _context.CreateConnection();
            return conn.Query(sql, map, param, splitOn: splitOn);
        }
        else
        {
            return _transaction.Connection.Query(sql, map, param, _transaction, splitOn: splitOn);
        }
    }
    
    protected T QuerySingle<T>(string sql, object param = null)
    {
        if (_transaction?.Connection == null)
        {
            using var conn = _context.CreateConnection();
            return conn.QuerySingle<T>(sql, param);
        }
        else
        {
            return _transaction.Connection.QuerySingle<T>(sql, param, _transaction);
        }
    }
    
    protected T QuerySingleOrDefault<T>(string sql, object param = null)
    {
        if (_transaction?.Connection == null)
        {
            using var conn = _context.CreateConnection();
            return conn.QuerySingleOrDefault<T>(sql, param);
        }
        else
        {
            return _transaction.Connection.QuerySingleOrDefault<T>(sql, param, _transaction);
        }
    }
    
    protected T ExecuteScalar<T>(string sql, object param = null)
    {
        if (_transaction?.Connection == null)
        {
            using var conn = _context.CreateConnection();
            return conn.ExecuteScalar<T>(sql, param);
        }
        else
        {
            return _transaction.Connection.ExecuteScalar<T>(sql, param, _transaction);
        }
    }
    
    protected int Execute(string sql, object param = null)
    {
        if (_transaction?.Connection == null)
        {
            using var conn = _context.CreateConnection();
            return conn.Execute(sql, param);
        }
        else
        {
            return _transaction.Connection.Execute(sql, param, _transaction);
        }
    }
}