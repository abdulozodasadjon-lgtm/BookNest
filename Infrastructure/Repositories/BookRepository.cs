using Dapper;
using Domain;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    public async Task AddBookAsync(Book book)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "insert into books (title, publishedyear, totalcopies, authorid, genreid) values (@Title, @PublishedYear, @TotalCopies, @AuthorId, @GenreId)";
        await conn.ExecuteAsync(query, book);
        Console.WriteLine("Added successfully!");
    }

    public async Task DeleteBookAsync(int id)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "delete from books where id = @id";
        await conn.ExecuteAsync(query, new { id });
        Console.WriteLine("Deleted!");
    }

    public async Task<Book> GetBookAsync(int id)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select id, title, publishedyear, totalcopies, authorid, genreid from books where id = @id";
        return await conn.QueryFirstOrDefaultAsync<Book>(query, new { id }) ?? new Book();
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select id, title, publishedyear, totalcopies, authorid, genreid from books";
        var books = await conn.QueryAsync<Book>(query);
        return books.ToList();
    }

    public async Task UpdateBookAsync(Book book)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "update books set title = @Title, publishedyear = @PublishedYear, totalcopies = @TotalCopies, authorid = @AuthorId, genreid = @GenreId where id = @Id";
        await conn.ExecuteAsync(query, book);
        Console.WriteLine("Updated successfully!");
    }

    public async Task<List<Book>> GetBooksByGenreAsync(int genreId)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select id, title, publishedyear, totalcopies, authorid, genreid from books where genreid = @genreId";
        var books = await conn.QueryAsync<Book>(query, new { genreId });
        return books.ToList();
    }

    public async Task<List<Book>> GetBooksByAuthorAsync(int authorId)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select id, title, publishedyear, totalcopies, authorid, genreid from books where authorid = @authorId";
        var books = await conn.QueryAsync<Book>(query, new { authorId });
        return books.ToList();
    }

    public async Task<int> GetBookAmountAsync()
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select count(*) from books";
        return await conn.QuerySingleAsync<int>(query);
    }

    public async Task<int> GetMinPublishedYearByAuthorAsync(int authorId)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select min(publishedyear) from books where authorid = @authorId";
        return await conn.QuerySingleAsync<int>(query, new { authorId });
    }

    public async Task<int> GetMaxPublishedYearByAuthorAsync(int authorId)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select max(publishedyear) from books where authorid = @authorId";
        return await conn.QuerySingleAsync<int>(query, new { authorId });
    }

    public async Task<int> GetMinPublishedYearByGenreAsync(int genreId)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select min(publishedyear) from books where genreid = @genreId";
        return await conn.QuerySingleAsync<int>(query, new { genreId });
    }

    public async Task<int> GetMaxPublishedYearByGenreAsync(int genreId)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select max(publishedyear) from books where genreid = @genreId";
        return await conn.QuerySingleAsync<int>(query, new { genreId });
    }

    public async Task<int> GetAmountByPublishedYearAsync(int publishedYear)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select count(*) from books where publishedyear = @publishedYear";
        return await conn.QuerySingleAsync<int>(query, new { publishedYear });
    }

    public async Task<int> GetAmountByGenreAsync(int genreId)
    {
        await using var conn = Database.Connection();
        await conn.OpenAsync();
        const string query = "select count(*) from books where genreid = @genreId";
        return await conn.QuerySingleAsync<int>(query, new { genreId });
    }
}
