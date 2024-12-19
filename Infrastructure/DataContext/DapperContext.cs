using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    readonly string connectionString = "Server=127.0.0.1;Port=5432;Database=restourant_db;User Id=postgres;Password=12345;";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
}