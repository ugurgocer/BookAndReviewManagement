namespace BookAndReviewManagement.Dtos;

public record ReviewCreateDto(
    int BookId,
    string ReviewerName,
    string Comment,
    int Rating
);