namespace BookAndReviewManagement.Dtos;

public record BookDto(
    int Id,
    string Title,
    string Author,
    DateTime PublishDate,
    string Genre
);