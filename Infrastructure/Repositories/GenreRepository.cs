using Domain;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Dapper;

namespace Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    public async Task AddGenreAsync(Genre genre)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "insert into genres (name) values (@name)";
        await conn.ExecuteAsync(query, new { genre.Name });
        Console.WriteLine("Genre added successfully!");
    }

    public async Task<Genre?> GetGenreAsync(int id)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select id, name from genres where id = @id";
        return await conn.QuerySingleOrDefaultAsync<Genre>(query, new { id });
    }

    public async Task<List<Genre>> GetAllGenresAsync()
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select id, name from genres";
        var genres = await conn.QueryAsync<Genre>(query);
        return genres.ToList();
    }

    public async Task UpdateGenreAsync(Genre genre)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "update genres set name = @name where id = @id";
        if (await conn.ExecuteAsync(query, new { genre.Id, genre.Name }) == 0)
        {
            Console.WriteLine($"No genre found with id {genre.Id}.");
            return;
        }

        Console.WriteLine("Genre updated successfully!");
    }

    public async Task DeleteGenreAsync(int id)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "delete from genres where id = @id";
        if (await conn.ExecuteAsync(query, new { id }) == 0)
        {
            Console.WriteLine($"No genre found with id {id}.");
            return;
        }

        Console.WriteLine("Genre deleted successfully!");
    }

    public async Task<int> GetAuthorsAmountAsync()
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "select count(*) from genres";
        return await conn.QuerySingleAsync<int>(query);
    }
}
