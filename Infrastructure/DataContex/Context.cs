using System.Data;
using Npgsql;

namespace Infrastructure.DataContex;

public interface IContext
{
    public IDbConnection GetConnection();
}

public class Context: IContext
{
    readonly string _connectionString = 
        "Server=localhost; Port = 5432; Database = exem; User Id = postgres; Password = 832111;";
    
    public IDbConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}