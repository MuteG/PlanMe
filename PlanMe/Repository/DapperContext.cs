using System.Data;
using Microsoft.Data.Sqlite;

namespace PlanMe.Repository;

public class DapperContext
{
    private readonly string _connectionString;
    
    public DapperContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(_connectionString);
    }
}