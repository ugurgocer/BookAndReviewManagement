using BookAndReviewManagement.Dtos;
using BookAndReviewManagement.Models;

namespace BookAndReviewManagement.Mapping;

public static class ReviewMapping
{
    public static Review ToEntity(this ReviewCreateDto reviewDto)
    {
        return new Review()
        {
            BookId = reviewDto.BookId,
            ReviewerName = reviewDto.ReviewerName,
            Comment = reviewDto.Comment,
            Rating = reviewDto.Rating
        };
    }
    
    public static ReviewDto ToDto(this Review review)
    {
        return new ReviewDto(
            review.Id,
            review.BookId,
            review.ReviewerName,
            review.Comment,
            review.Rating
        );
    }
}