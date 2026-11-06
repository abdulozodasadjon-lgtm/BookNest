using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IGenreService
{
    Task<ApiResponse<List<Genre>>> GetAllGenresAsync();
    Task<ApiResponse<Genre>> GetGenreAsync(int id);
    Task<ApiResponse<bool>> AddGenreAsync(Genre genre);
    Task<ApiResponse<bool>> UpdateGenreAsync(Genre genre);
    Task<ApiResponse<bool>> DeleteGenreAsync(int id);
}
