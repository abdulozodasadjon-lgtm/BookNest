using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/books")]
public sealed class BooksController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllBooks() =>
        ToActionResult(await bookService.GetAllBooksAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBook(int id) =>
        ToActionResult(await bookService.GetBookAsync(id));

    [HttpGet("by-author/{authorId:int}")]
    public async Task<IActionResult> GetBooksByAuthor(int authorId) =>
        ToActionResult(await bookService.GetBooksByAuthorAsync(authorId));

    [HttpGet("by-genre/{genreId:int}")]
    public async Task<IActionResult> GetBooksByGenre(int genreId) =>
        ToActionResult(await bookService.GetBooksByGenreAsync(genreId));

    [HttpPost]
    public async Task<IActionResult> AddBook(Book book) =>
        ToActionResult(await bookService.AddBookAsync(book));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBook(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest(new { message = "Route ID must match the book ID." });

        return ToActionResult(await bookService.UpdateBookAsync(book));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBook(int id) =>
        ToActionResult(await bookService.DeleteBookAsync(id));

    private IActionResult ToActionResult<T>(ApiResponse<T> response) =>
        StatusCode((int)response.StatusCode, response);
}
