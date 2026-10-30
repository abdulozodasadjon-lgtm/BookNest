using Dapper;
using Domain;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{

    public async Task AddAuthorAsync(Author author)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "insert into authors (fullname, country, birthyear) values (@fullname, @country, @birthyear)";
        await conn.ExecuteAsync(query, new {author.Fullname, author.Country, author.BirthYear});
    }


    public async Task DeleteAuthorAsync(int id)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "delete from authors where id = @id";
        var a = await conn.ExecuteAsync(query, new {id});
        if(a > 0) System.Console.WriteLine($"Successfuly!");
        else System.Console.WriteLine($"Something went wrong!");
    }

    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select id, fullname, country, birthyear from authors";
        var authors = await conn.QueryAsync<Author>(query);
        return authors.ToList();
    }

    public async Task<Author?> GetAuthorAsync(int id)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select id, fullname, country, birthyear from authors where id = @id";
        return await conn.QuerySingleOrDefaultAsync<Author>(query, new { id });
    }

    public async Task UpdateAuthorAsync(Author author)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "update authors set fullname = @fullname, country = @country, birthyear = @birthyear where id = @id";
        if (await conn.ExecuteAsync(query, new
        {
            author.Id,
            author.Fullname,
            author.Country,
            author.BirthYear
        }) == 0)
        {
            Console.WriteLine($"No author found with id {author.Id}.");
            return;
        }

        Console.WriteLine("Author updated successfully!");
    }

    public async Task<int> GetAuthorsAmountAsync()
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        var query = "select count(*) from authors";
        return await conn.QuerySingleAsync<int>(query);
    }

}