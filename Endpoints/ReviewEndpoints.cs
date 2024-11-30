using BookAndReviewManagement.Data;
using BookAndReviewManagement.Dtos;
using BookAndReviewManagement.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BookAndReviewManagement.Endpoints;

public static class ReviewEndpoints
{
    private const string BasePath = "/api/reviews";

    public static WebApplication AddReviewEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(BasePath);

        group.MapGet("/", async (BookReviewContext dbContext, int bookId) =>
        {
            Console.WriteLine(bookId);
            
            return await dbContext.Reviews
                .Where(review => review.BookId == bookId)
                .Include(review => review.Book)
                .Select(review => review.ToDto())
                .AsNoTracking()
                .ToListAsync();
        });

        group.MapPost("/", async (BookReviewContext dbContext, ReviewCreateDto createDto) =>
        {
            var review = createDto.ToEntity();
            
            dbContext.Reviews.Add(review);
            await dbContext.SaveChangesAsync();
            
            return Results.Created();
        });

        group.MapDelete("/{id:int}", async (BookReviewContext dbContext, int id) =>
        {
            await dbContext.Reviews.Where(review => review.Id == id).ExecuteDeleteAsync();
            
            return Results.NoContent();
        });

        return app;
    }
}