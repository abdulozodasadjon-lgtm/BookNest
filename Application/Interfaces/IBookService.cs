using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IBookService
{
    Task<ApiResponse<List<Book>>> GetAllBooksAsync();
    Task<ApiResponse<Book>> GetBookAsync(int id);
    Task<ApiResponse<List<Book>>> GetBooksByAuthorAsync(int authorId);
    Task<ApiResponse<List<Book>>> GetBooksByGenreAsync(int genreId);
    Task<ApiResponse<bool>> AddBookAsync(Book book);
    Task<ApiResponse<bool>> UpdateBookAsync(Book book);
    Task<ApiResponse<bool>> DeleteBookAsync(int id);
}
