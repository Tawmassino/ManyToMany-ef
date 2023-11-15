using System.ComponentModel.DataAnnotations;

namespace ManyToMany_ef.Database.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public Category Category { get; set; }

        public Author Author { get; set; }

        //kompozicija i category
        public List<BookCategory> BookCategories { get; set; }


    }

}
