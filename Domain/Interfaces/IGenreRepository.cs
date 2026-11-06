using Domain.Models;

namespace Domain.Interfaces;

public interface IGenreRepository
{
    Task<bool> AddGenreAsync(Genre genre);
    Task<Genre?> GetGenreAsync(int id);
    Task<List<Genre>> GetAllGenresAsync();
    Task<bool> UpdateGenreAsync(Genre genre);
    Task<bool> DeleteGenreAsync(int id);
}
