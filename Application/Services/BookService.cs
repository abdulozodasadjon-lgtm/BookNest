using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class BookService(IBookRepository bookRepository) : IBookService
{
    public async Task<ApiResponse<List<Book>>> GetAllBooksAsync()
    {
        var books = await bookRepository.GetAllBooksAsync();
        return new ApiResponse<List<Book>>(HttpStatusCode.OK, "List of books.", books);
    }

    public async Task<ApiResponse<Book>> GetBookAsync(int id)
    {
        var book = await bookRepository.GetBookAsync(id);
        return book.Id == 0
            ? new ApiResponse<Book>(HttpStatusCode.NotFound, $"Book with id {id} not found.")
            : new ApiResponse<Book>(HttpStatusCode.OK, "Book with given id.", book);
    }

    public async Task<ApiResponse<List<Book>>> GetBooksByAuthorAsync(int authorId)
    {
        var books = await bookRepository.GetBooksByAuthorAsync(authorId);
        return new ApiResponse<List<Book>>(HttpStatusCode.OK, "Books by author.", books);
    }

    public async Task<ApiResponse<List<Book>>> GetBooksByGenreAsync(int genreId)
    {
        var books = await bookRepository.GetBooksByGenreAsync(genreId);
        return new ApiResponse<List<Book>>(HttpStatusCode.OK, "Books by genre.", books);
    }

    public async Task<ApiResponse<bool>> AddBookAsync(Book book)
    {
        var ok = await bookRepository.AddBookAsync(book);
        return ok
            ? new ApiResponse<bool>(HttpStatusCode.Created, "Added!", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", false);
    }

    public async Task<ApiResponse<bool>> UpdateBookAsync(Book book)
    {
        var ok = await bookRepository.UpdateBookAsync(book);
        return ok
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, "Book not found.", false);
    }

    public async Task<ApiResponse<bool>> DeleteBookAsync(int id)
    {
        var ok = await bookRepository.DeleteBookAsync(id);
        return ok
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, "Book not found.", false);
    }
}
