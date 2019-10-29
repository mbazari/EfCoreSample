using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorsLink> AuthorsLinks { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PriceOffer> Promotion { get; set; }
    }

    public class Review
    {
        public long ReviewId { get; set; }
        public string VoterName { get; set; }
        public byte NumStars { get; set; }
        public string Comment { get; set; }

        public long BookId { get; set; }
    }
    public class Author
    {
        public long AuthorId { get; set; }
        public string Name { get; set; }

        public ICollection<AuthorsLink> AuthorsLinks { get; set; }
    }

    public class PriceOffer
    {
        public long PriceOfferId { get; set; }
        public decimal NewPrice { get; set; }
        public string PromotionalText { get; set; }

        public long BookId { get; set; }

    }
    public class Book
    {
        public long BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal Price { get; set; }


        public ICollection<Review> Reviews { get; set; }
        public PriceOffer Promotion { get; set; }
        public ICollection<AuthorsLink> AuthorsLinks { get; set; }
    }

    public class AuthorsLink
    {
        public long AuthorsLinkId { get; set; }
        public long BookId { get; set; }
        public long AuthorId { get; set; }
        public byte Order { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
