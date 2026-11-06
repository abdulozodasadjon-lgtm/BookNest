using Domain.Models;

namespace Domain.Interfaces;

public interface IBookRepository
{
    Task<bool> AddBookAsync(Book book);
    Task<Book> GetBookAsync(int id);
    Task<List<Book>> GetAllBooksAsync();
    Task<bool> UpdateBookAsync(Book book);
    Task<bool> DeleteBookAsync(int id);
    Task<List<Book>> GetBooksByGenreAsync(int genreId);
    Task<List<Book>> GetBooksByAuthorAsync(int authorId);
}
