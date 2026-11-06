using Domain.Models;

namespace Domain.Interfaces;

public interface IAuthorRepository
{
    Task<bool> AddAuthorAsync(Author author);
    Task<Author?> GetAuthorAsync(int id);
    Task<List<Author>> GetAllAuthorsAsync();
    Task<bool> UpdateAuthorAsync(Author author);
    Task<bool> DeleteAuthorAsync(int id);
}
