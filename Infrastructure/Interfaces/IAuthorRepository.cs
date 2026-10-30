using Domain;

namespace Infrastructure.Repositories;

public interface IAuthorRepository
{
    Task AddAuthorAsync(Author author);
    Task<Author?> GetAuthorAsync(int id);
    Task<List<Author>> GetAllAuthorsAsync();
    Task DeleteAuthorAsync(int id);
    Task UpdateAuthorAsync(Author author);
}
