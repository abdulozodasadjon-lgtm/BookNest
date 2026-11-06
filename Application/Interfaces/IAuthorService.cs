using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IAuthorService
{
    Task<ApiResponse<List<Author>>> GetAllAuthorsAsync();
    Task<ApiResponse<Author>> GetAuthorAsync(int id);
    Task<ApiResponse<bool>> AddAuthorAsync(Author author);
    Task<ApiResponse<bool>> UpdateAuthorAsync(Author author);
    Task<ApiResponse<bool>> DeleteAuthorAsync(int id);
}
