using System.ComponentModel.DataAnnotations;

namespace BookAndReviewManagement.Models;

public class Book
{
    public int Id { get; set; }
    [StringLength(200)]
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required DateTime PublishDate { get; set; }
    public string Genre { get; set; }
}