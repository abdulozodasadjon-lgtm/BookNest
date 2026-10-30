using Domain;



namespace Infrastructure.Interfaces;

public interface IBookRepository
{
    Task AddBookAsync(Book book);
    Task<Book> GetBookAsync(int id);
    Task<List<Book>> GetAllBooksAsync();
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);
    Task<List<Book>> GetBooksByGenreAsync(int genreId);
    Task<List<Book>> GetBooksByAuthorAsync(int authorId);
}
