namespace BookAndReviewManagement.Dtos;

public record ReviewDto(
    int Id,
    int BookId,
    string ReviewerName,
    string? Comment,
    int Rating
);