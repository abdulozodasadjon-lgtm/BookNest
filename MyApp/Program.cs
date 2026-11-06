

using Infrastructure.Repositories;
using Domain;
using System.Reflection;
using Domain.Interfaces;

var bookr = new BookRepository();
        var authorRepository = new AuthorRepository();
        var genreRepository = new GenreRepository();

        while (true)
        {
            System.Console.WriteLine("""
_____________________________________________________________

========== Please select the option you want to do ==========

                    |   1. Get all books.  |
                    ------------------------
                    |  2. Get book by id.  |
                    ------------------------
                    |      3. Add book.    |
                    ------------------------
                    |   4. Update book.    |
                    ------------------------
                    |   5. Delete book.    |
                    ------------------------
                    | 6. Get all authors.  |
                    ------------------------
                    | 7. Get author by id. |
                    ------------------------
                    |    8. Add author.    |
                    ------------------------
                    |  9. Update author.   |
                    ------------------------
                    |  10. Delete author.  |
                    ------------------------
                    |  11. Get all genres. |
                    ------------------------
                    |  12. Get genre by id.|
                    ------------------------
                    |     13. Add genre.   |
                    ------------------------
                    |   14. Update genre.  |
                    ------------------------
                    |   15. Delete genre.  |
                    ------------------------
                    |16. Get books by author|
                    ------------------------
                    |17. Get books by genre|
                    ------------------------
                    |        0. Exit.      |
                    ------------------------
___________________________________________________________________



""");
            var choise = Convert.ToInt32(Console.ReadLine());



            System.Console.WriteLine("""
            
            


            """);

            switch (choise)
            {
                case 1:
                    List<Book> books = await bookr.GetAllBooksAsync();
                    Console.WriteLine(" Title   PublishedYear  TotalCopies  AuthorId  GenreId");
                    foreach (var b in books)
                    {
                        Console.WriteLine($"{b.Title}     {b.PublishedYear}          {b.TotalCopies}        {b.AuthorId}       {b.GenreId}");
                    }
                    break;

                case 2:
                    System.Console.Write($"Enter id: ");
                    int get_id = Convert.ToInt32(Console.ReadLine());
                    Book book = await bookr.GetBookAsync(get_id);
                    Console.WriteLine(" Title   PublishedYear  TotalCopies  AuthorId  GenreId");
                    Console.WriteLine($"{book.Title}  {book.PublishedYear}  {book.TotalCopies}  {book.AuthorId}  {book.GenreId}");
                    break;

                case 3:
                    System.Console.Write($"Enter title of the book: ");
                    string atitle = Console.ReadLine()!;
                    System.Console.Write($"Enter publish year of book: ");
                    int apy = Convert.ToInt32(Console.ReadLine());
                    System.Console.Write($"Enter total copies of book: ");
                    int atc = Convert.ToInt32(Console.ReadLine());
                    System.Console.Write($"Enter author id: ");
                    int authorId = Convert.ToInt32(Console.ReadLine());
                    System.Console.Write($"Enter genre id: ");
                    int genreId = Convert.ToInt32(Console.ReadLine());
                    Book book1 = new Book();
                    book1.Title = atitle;
                    book1.PublishedYear = apy;
                    book1.TotalCopies = atc;
                    book1.AuthorId = authorId;
                    book1.GenreId = genreId;
                    await bookr.AddBookAsync(book1);
                    break;

                case 4:
                    System.Console.Write($"Enter id of book: ");
                    int uid = Convert.ToInt32(Console.ReadLine());
                    System.Console.Write($"Enter title of book: ");
                    string utitle = Console.ReadLine()!;
                    System.Console.Write($"Enter publish year of book: ");
                    int upy = Convert.ToInt32(Console.ReadLine());
                    System.Console.Write($"Enter total copies of book: ");
                    int utc = Convert.ToInt32(Console.ReadLine());
                    System.Console.Write($"Enter author id: ");
                    int updateAuthorId = Convert.ToInt32(Console.ReadLine());
                    System.Console.Write($"Enter genre id: ");
                    int updateGenreId = Convert.ToInt32(Console.ReadLine());
                    Book book2 = new Book()
                    {
                        Id = uid,
                        Title = utitle,
                        PublishedYear = upy,
                        TotalCopies = utc,
                        AuthorId = updateAuthorId,
                        GenreId = updateGenreId
                    };
                    await bookr.UpdateBookAsync(book2);
                    break;

                case 5:
                    System.Console.Write($"Enter id: ");
                    int did = Convert.ToInt32(Console.ReadLine());
                    await bookr.DeleteBookAsync(did);
                    break;

                case 6:
                    List<Author> authors = await authorRepository.GetAllAuthorsAsync();
                    Console.WriteLine("Full name  Country  Birth year \n");
                    foreach (var author in authors)
                    {
                        Console.WriteLine($"{author.Fullname}  {author.Country}  {author.BirthYear}");
                    }
                    break;

                case 7:
                    Console.Write("Enter author id: ");
                    int getAuthorId = Convert.ToInt32(Console.ReadLine());
                    Author? foundAuthor = await authorRepository.GetAuthorAsync(getAuthorId);
                    if (foundAuthor is null)
                    {
                        Console.WriteLine($"No author found with id {getAuthorId}.");
                    }
                    else
                    {
                        Console.WriteLine($"{foundAuthor.Fullname}  {foundAuthor.Country}  {foundAuthor.BirthYear}");
                    }
                    break;

                case 8:
                    Console.Write("Enter author's full name: ");
                    string authorName = Console.ReadLine()!;
                    Console.Write("Enter author's country: ");
                    string authorCountry = Console.ReadLine()!;
                    Console.Write("Enter author's birth year: ");
                    int authorBirthYear = Convert.ToInt32(Console.ReadLine());
                    await authorRepository.AddAuthorAsync(new Author
                    {
                        Fullname = authorName,
                        Country = authorCountry,
                        BirthYear = authorBirthYear
                    });
                    break;

                case 9:
                    Console.Write("Enter id of author: ");
                    updateAuthorId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter author's full name: ");
                    string updatedAuthorName = Console.ReadLine()!;
                    Console.Write("Enter author's country: ");
                    string updatedAuthorCountry = Console.ReadLine()!;
                    Console.Write("Enter author's birth year: ");
                    int updatedAuthorBirthYear = Convert.ToInt32(Console.ReadLine());
                    await authorRepository.UpdateAuthorAsync(new Author
                    {
                        Id = updateAuthorId,
                        Fullname = updatedAuthorName,
                        Country = updatedAuthorCountry,
                        BirthYear = updatedAuthorBirthYear
                    });
                    break;

                case 10:
                    Console.Write("Enter author id: ");
                    int deleteAuthorId = Convert.ToInt32(Console.ReadLine());
                    await authorRepository.DeleteAuthorAsync(deleteAuthorId);
                    break;

                case 11:
                    List<Genre> genres = await genreRepository.GetAllGenresAsync();
                    Console.WriteLine("Genre");
                    foreach (var genre in genres)
                    {
                        Console.WriteLine(genre.Name);
                    }
                    break;

                case 12:
                    Console.Write("Enter genre id: ");
                    int getGenreId = Convert.ToInt32(Console.ReadLine());
                    Genre? foundGenre = await genreRepository.GetGenreAsync(getGenreId);
                    Console.WriteLine(foundGenre is null
                        ? $"No genre found with id {getGenreId}."
                        : foundGenre.Name);
                    break;

                case 13:
                    Console.Write("Enter genre name: ");
                    string genreName = Console.ReadLine()!;
                    await genreRepository.AddGenreAsync(new Genre { Name = genreName });
                    break;

                case 14:
                    Console.Write("Enter genre id: ");
                    int editGenreId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new genre name: ");
                    string updatedGenreName = Console.ReadLine()!;
                    await genreRepository.UpdateGenreAsync(new Genre
                    {
                        Id = editGenreId,
                        Name = updatedGenreName
                    });
                    break;

                case 15:
                    Console.Write("Enter genre id: ");
                    int deleteGenreId = Convert.ToInt32(Console.ReadLine());
                    await genreRepository.DeleteGenreAsync(deleteGenreId);
                    break;

                case 16:
                    Console.Write("Enter author id: ");
                    int authorIdForBooks = Convert.ToInt32(Console.ReadLine());
                    List<Book> booksByAuthor = await bookr.GetBooksByAuthorAsync(authorIdForBooks);
                    if (booksByAuthor.Count == 0)
                    {
                        Console.WriteLine($"No books found for author with id {authorIdForBooks}.");
                    }
                    else
                    {
                        Console.WriteLine("Title  PublishedYear  TotalCopies  AuthorId  GenreId");
                        foreach (var b in booksByAuthor)
                        {
                            Console.WriteLine($"{b.Title}  {b.PublishedYear}  {b.TotalCopies}  {b.AuthorId}  {b.GenreId}");
                        }
                    }
                    break;

                case 17:
                    Console.Write("Enter genre id: ");
                    int genreIdForBooks = Convert.ToInt32(Console.ReadLine());
                    List<Book> booksByGenre = await bookr.GetBooksByGenreAsync(genreIdForBooks);
                    if (booksByGenre.Count == 0)
                    {
                        Console.WriteLine($"No books found for genre with id {genreIdForBooks}.");
                    }
                    else
                    {
                        Console.WriteLine("Title  PublishedYear  TotalCopies  AuthorId  GenreId");
                        foreach (var b in booksByGenre)
                        {
                            Console.WriteLine($"{b.Title}  {b.PublishedYear}  {b.TotalCopies}  {b.AuthorId}  {b.GenreId}");
                        }
                    }
                    break;

                case 0:
                    Console.WriteLine("Exiting the program...");
                    return;
            }

        }