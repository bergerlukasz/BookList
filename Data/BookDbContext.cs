using BookList.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookList.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public void Seed()
        {
            if (!Books.Any())
            {
                Books.Add(new Book
                {
                    Title = "Pan Tadeusz",
                    Author = "Adam Mickiewicz",
                    Year = 2018,
                    ISBN = "9788381392389", // EAN BARCODE OF ISBN
                    Pages = 296
                });
                Books.Add(new Book
                {
                    Title = "Blood of Elves (The Witcher Book 1)",
                    Author = "Andrzej Sapkowski",
                    Year = 2023,
                    ISBN = "978-83-7578-065-9",
                    Pages = 340
                });
                SaveChanges();
            }
        }
    }
}
