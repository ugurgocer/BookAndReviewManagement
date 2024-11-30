using Microsoft.EntityFrameworkCore;

namespace BookAndReviewManagement.Data;

public static class DataExtensions
{
    public static async Task MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BookReviewContext>();

        await dbContext.Database.MigrateAsync();
    }
}