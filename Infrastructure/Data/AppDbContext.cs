using Npgsql;

namespace Infrastructure.Data;

public class AppDbContext
{
    private readonly string _connectionString =
        Environment.GetEnvironmentVariable("BOOKNEST_CONNECTION")
        ?? "Host=localhost;Port=5432;Database=BookNest;Username=postgres;Password=CHANGE_ME";

    public NpgsqlConnection Connection() => new NpgsqlConnection(_connectionString);
}
