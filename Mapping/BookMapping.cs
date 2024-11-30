using BookAndReviewManagement.Dtos;
using BookAndReviewManagement.Models;

namespace BookAndReviewManagement.Mapping;

public static class BookMapping
{
    public static BookDto ToDto(this Book book)
    {
        return new BookDto(
            book.Id,
            book.Title,
            book.Author,
            book.PublishDate,
            book.Genre
        );
    }

    public static Book ToEntity(this BookCreateDto bookDto)
    {
        return new Book()
        {
            Title = bookDto.Title,
            Author = bookDto.Author,
            PublishDate = bookDto.PublishDate,
            Genre = bookDto.Genre
        };
    }
    
    public static Book ToEntity(this BookCreateDto bookDto, int id)
    {
        return new Book()
        {
            Id = id,
            Title = bookDto.Title,
            Author = bookDto.Author,
            PublishDate = bookDto.PublishDate,
            Genre = bookDto.Genre
        };
    }
}