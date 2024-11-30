namespace BookAndReviewManagement.Dtos;

public record BookCreateDto(
    string Title,
    string Author,
    DateTime PublishDate,
    string Genre
);