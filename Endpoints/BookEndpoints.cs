using BookAndReviewManagement.Data;
using BookAndReviewManagement.Dtos;
using BookAndReviewManagement.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BookAndReviewManagement.Endpoints;

public static class BookEndpoints
{
    private const string BasePath = "/api/books";

    public static WebApplication AddBookEndpoints(this WebApplication app)
    {
        const string getByIdEndpointName = "GetBookById";
        
        var group = app.MapGroup(BasePath);

        group.MapGet("/", async (BookReviewContext dbContext) =>
        {
            return await dbContext.Books
                .Select(book => book.ToDto())
                .AsNoTracking()
                .ToListAsync();
        });

        group.MapGet("/{id:int}", async (BookReviewContext dbContext, int id) =>
        {
            var book = await dbContext.Books.FindAsync(id);
            
            return book is null ? Results.NotFound() : Results.Ok(book.ToDto());
        })
            .WithName(getByIdEndpointName)
            .WithDisplayName("Get Book By Id");

        group.MapPost("/", async (BookReviewContext dbContext, BookCreateDto bookDto) =>
        {
            var book = bookDto.ToEntity();
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();
            
            return Results.CreatedAtRoute(getByIdEndpointName, new { id = book.Id }, book.ToDto());
        });

        group.MapPut("/{id:int}", async (BookReviewContext dbContext, int id, BookCreateDto bookDto) =>
        {
            var existDb = await dbContext.Books.FindAsync(id);
            
            if(existDb is null)
                return Results.NotFound();
            
            dbContext
                .Entry(existDb)
                .CurrentValues
                .SetValues(bookDto.ToEntity(id));
            
            await dbContext.SaveChangesAsync();
            
            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (BookReviewContext dbContext, int id) =>
        {
            await dbContext.Books.Where(book => book.Id == id).ExecuteDeleteAsync();
            
            return Results.NoContent();
        });
        
        return app;
    }
}