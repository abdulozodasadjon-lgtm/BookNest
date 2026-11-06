using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/genres")]
public sealed class GenresController(IGenreService genreService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllGenres() =>
        ToActionResult(await genreService.GetAllGenresAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetGenre(int id) =>
        ToActionResult(await genreService.GetGenreAsync(id));

    [HttpPost]
    public async Task<IActionResult> AddGenre(Genre genre) =>
        ToActionResult(await genreService.AddGenreAsync(genre));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateGenre(int id, Genre genre)
    {
        if (id != genre.Id)
            return BadRequest(new { message = "Route ID must match the genre ID." });

        return ToActionResult(await genreService.UpdateGenreAsync(genre));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteGenre(int id) =>
        ToActionResult(await genreService.DeleteGenreAsync(id));

    private IActionResult ToActionResult<T>(ApiResponse<T> response) =>
        StatusCode((int)response.StatusCode, response);
}
