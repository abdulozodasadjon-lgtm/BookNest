using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AuthorRepository(AppDbContext context) : IAuthorRepository
{
    public async Task<bool> AddAuthorAsync(Author author)
    {
        await using var conn = context.Connection();
        await conn.OpenAsync();
        const string query = "insert into authors (fullname, country, birthyear) values (@Fullname, @Country, @BirthYear)";
        return await conn.ExecuteAsync(query, author) > 0;
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        await using var conn = context.Connection();
        await conn.OpenAsync();
        const string query = "delete from authors where id = @id";
        return await conn.ExecuteAsync(query, new { id }) > 0;
    }

    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        await using var conn = context.Connection();
        await conn.OpenAsync();
        const string query = "select id, fullname, country, birthyear from authors";
        var authors = await conn.QueryAsync<Author>(query);
        return authors.ToList();
    }

    public async Task<Author?> GetAuthorAsync(int id)
    {
        await using var conn = context.Connection();
        await conn.OpenAsync();
        const string query = "select id, fullname, country, birthyear from authors where id = @id";
        return await conn.QuerySingleOrDefaultAsync<Author>(query, new { id });
    }

    public async Task<bool> UpdateAuthorAsync(Author author)
    {
        await using var conn = context.Connection();
        await conn.OpenAsync();
        const string query = "update authors set fullname = @Fullname, country = @Country, birthyear = @BirthYear where id = @Id";
        return await conn.ExecuteAsync(query, author) > 0;
    }

    public async Task<int> GetAuthorsAmountAsync()
    {
        await using var conn = context.Connection();
        await conn.OpenAsync();
        const string query = "select count(*) from authors";
        return await conn.QuerySingleAsync<int>(query);
    }
}
