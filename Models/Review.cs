using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookAndReviewManagement.Models;

public class Review
{
    public int Id { get; set; }
    public required int BookId { get; set; }
    public Book Book { get; set; }
    public required string ReviewerName { get; set; }
    public string? Comment { get; set; }
    [Range(1, 5)]
    public int Rating { get; set; }
}