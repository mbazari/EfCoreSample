using BookApp.Core;
using BookApp.Data;
using BookApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.ViewModel
{
    public static class Extensions
    {
        public static IQueryable<BookDto> MapBookToDto(
            this IQueryable<Book> books)
        {
            return books.Select(p => new BookDto
            {
                BookId = p.BookId,
                Title = p.Title,
                Price = p.Price,
                PublishedOn = p.PublishedOn,
                ActualPrice = p.Promotion == null ? p.Price : p.Promotion.NewPrice,
                PromotionPromotionalText = p.Promotion == null ? null : p.Promotion.PromotionalText,
                AuthorsOrdered = string.Join(", ", p.AuthorsLinks.OrderBy(q => q.Order).Select(q => q.Author.Name)),
                ReviewsCount = p.Reviews.Count,
                ReviewsAverageVotes = p.Reviews.Select(y => (double?)y.NumStars).Average()

            });
        }

        public static IQueryable<BookDto> OrderBooksBy(this IQueryable<BookDto> books, OrderByOptions orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptions.SimpleOrder:
                    return books.OrderByDescending(x => x.BookId);
                case OrderByOptions.ByVotes:
                    return books.OrderByDescending(x =>x.ReviewsAverageVotes);
                case OrderByOptions.ByPublicationDate:
                    return books.OrderByDescending(x => x.PublishedOn);
                case OrderByOptions.ByPriceLowestFirst:
                    return books.OrderBy(x => x.ActualPrice);
                case OrderByOptions.ByPriceHigestFirst:
                    return books.OrderByDescending(x => x.ActualPrice);
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(orderByOptions), orderByOptions, null);
            }
        }


    }
}
