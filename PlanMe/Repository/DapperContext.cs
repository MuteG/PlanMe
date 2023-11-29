using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using Avalonia.Platform;

namespace PlanMe.Repository;

public class DapperContext
{
    private const string SOURCE_SQLITE = "plan.db";
    private readonly string _source;
    
    public DapperContext(string source)
    {
        _source = source;
    }
    public IDbConnection CreateConnection()
    {
        var builder = new SQLiteConnectionStringBuilder()
        {
            DataSource = _source
        };
        return new SQLiteConnection(builder.ConnectionString);
    }

    public static DapperContext Sqlite
    {
        get
        {
            if (!File.Exists(SOURCE_SQLITE))
            {
                using var stream = AssetLoader.Open(new Uri($"avares://PlanMe/{SOURCE_SQLITE}"));
                using var file = new FileStream(SOURCE_SQLITE, FileMode.Create);
                stream.CopyTo(file);
                file.Flush();
            }
        
            return new DapperContext(Path.GetFullPath(SOURCE_SQLITE));
        }
    }
}