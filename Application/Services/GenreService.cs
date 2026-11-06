using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class GenreService(IGenreRepository genreRepository) : IGenreService
{
    public async Task<ApiResponse<List<Genre>>> GetAllGenresAsync()
    {
        var genres = await genreRepository.GetAllGenresAsync();
        return new ApiResponse<List<Genre>>(HttpStatusCode.OK, "List of genres.", genres);
    }

    public async Task<ApiResponse<Genre>> GetGenreAsync(int id)
    {
        var genre = await genreRepository.GetGenreAsync(id);
        return genre is null
            ? new ApiResponse<Genre>(HttpStatusCode.NotFound, $"Genre with id {id} not found.")
            : new ApiResponse<Genre>(HttpStatusCode.OK, "Genre with given id.", genre);
    }

    public async Task<ApiResponse<bool>> AddGenreAsync(Genre genre)
    {
        var ok = await genreRepository.AddGenreAsync(genre);
        return ok
            ? new ApiResponse<bool>(HttpStatusCode.Created, "Added!", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", false);
    }

    public async Task<ApiResponse<bool>> UpdateGenreAsync(Genre genre)
    {
        var ok = await genreRepository.UpdateGenreAsync(genre);
        return ok
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, "Genre not found.", false);
    }

    public async Task<ApiResponse<bool>> DeleteGenreAsync(int id)
    {
        var ok = await genreRepository.DeleteGenreAsync(id);
        return ok
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, "Genre not found.", false);
    }
}
