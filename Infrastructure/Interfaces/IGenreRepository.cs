using Domain;

namespace Infrastructure.Interfaces;

public interface IGenreRepository
{
    Task AddGenreAsync(Genre genre);
    Task<Genre?> GetGenreAsync(int id);
    Task<List<Genre>> GetAllGenresAsync();
    Task UpdateGenreAsync(Genre genre);
    Task DeleteGenreAsync(int id);
}
