using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GenreRepository(AppDbContext context) : IGenreRepository
{
    public async Task<bool> AddGenreAsync(Genre genre)
    {
        await using var conn = context.Connection();
        await conn.OpenAsync();
        const string query = "insert into genres (name) values (@Name)";
        return await conn.ExecuteAsync(query, new { genre.Name }) > 0;
    }

    public async Task<Genre?> GetGenreAsync(int id)
    {
        await using var conn = context.Connection();
        await conn.OpenAsync();
        const string query = "select id, name from genres where id = @id";
        return await conn.QuerySingleOrDefaultAsync<Genre>(query, new { id });
    }

    public async Task<List<Genre>> GetAllGenresAsync()
    {
        await using var conn = context.Connection();
        await conn.OpenAsync();
        const string query = "select id, name from genres";
        var genres = await conn.QueryAsync<Genre>(query);
        return genres.ToList();
    }

    public async Task<bool> UpdateGenreAsync(Genre genre)
    {
        await using var conn = context.Connection();
        await conn.OpenAsync();
        const string query = "update genres set name = @Name where id = @Id";
        return await conn.ExecuteAsync(query, new { genre.Id, genre.Name }) > 0;
    }

    public async Task<bool> DeleteGenreAsync(int id)
    {
        await using var conn = context.Connection();
        await conn.OpenAsync();
        const string query = "delete from genres where id = @id";
        return await conn.ExecuteAsync(query, new { id }) > 0;
    }

    public async Task<int> GetGenresAmountAsync()
    {
        await using var conn = context.Connection();
        await conn.OpenAsync();
        const string query = "select count(*) from genres";
        return await conn.QuerySingleAsync<int>(query);
    }
}
