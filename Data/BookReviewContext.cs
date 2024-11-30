using BookAndReviewManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAndReviewManagement.Data;

public class BookReviewContext(DbContextOptions<BookReviewContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Review> Reviews => Set<Review>();
}