using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class AuthorService(IAuthorRepository authorRepository) : IAuthorService
{
    public async Task<ApiResponse<List<Author>>> GetAllAuthorsAsync()
    {
        var authors = await authorRepository.GetAllAuthorsAsync();
        return new ApiResponse<List<Author>>(HttpStatusCode.OK, "List of authors.", authors);
    }

    public async Task<ApiResponse<Author>> GetAuthorAsync(int id)
    {
        var author = await authorRepository.GetAuthorAsync(id);
        return author is null
            ? new ApiResponse<Author>(HttpStatusCode.NotFound, $"Author with id {id} not found.")
            : new ApiResponse<Author>(HttpStatusCode.OK, "Author with given id.", author);
    }

    public async Task<ApiResponse<bool>> AddAuthorAsync(Author author)
    {
        var ok = await authorRepository.AddAuthorAsync(author);
        return ok
            ? new ApiResponse<bool>(HttpStatusCode.Created, "Added!", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", false);
    }

    public async Task<ApiResponse<bool>> UpdateAuthorAsync(Author author)
    {
        var ok = await authorRepository.UpdateAuthorAsync(author);
        return ok
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, "Author not found.", false);
    }

    public async Task<ApiResponse<bool>> DeleteAuthorAsync(int id)
    {
        var ok = await authorRepository.DeleteAuthorAsync(id);
        return ok
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, "Author not found.", false);
    }
}
