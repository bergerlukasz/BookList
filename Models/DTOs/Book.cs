using System.ComponentModel.DataAnnotations;

namespace BookList.Models.DTOs
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public int Pages { get; set; }
    }
}
