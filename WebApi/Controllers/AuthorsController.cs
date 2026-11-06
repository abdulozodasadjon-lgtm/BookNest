using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/authors")]
public sealed class AuthorsController(IAuthorService authorService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAuthors() =>
        ToActionResult(await authorService.GetAllAuthorsAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAuthor(int id) =>
        ToActionResult(await authorService.GetAuthorAsync(id));

    [HttpPost]
    public async Task<IActionResult> AddAuthor(Author author) =>
        ToActionResult(await authorService.AddAuthorAsync(author));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAuthor(int id, Author author)
    {
        if (id != author.Id)
            return BadRequest(new { message = "Route ID must match the author ID." });

        return ToActionResult(await authorService.UpdateAuthorAsync(author));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAuthor(int id) =>
        ToActionResult(await authorService.DeleteAuthorAsync(id));

    private IActionResult ToActionResult<T>(ApiResponse<T> response) =>
        StatusCode((int)response.StatusCode, response);
}
