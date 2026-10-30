using Npgsql;

namespace Infrastructure.Data;

public static class Database
{
    private static string connectionString = "Host=localhost;Port=5432;Database=BookNest;Username=postgres;Password=1234554321";
    public static NpgsqlConnection Connection()=>new NpgsqlConnection(connectionString);
}
