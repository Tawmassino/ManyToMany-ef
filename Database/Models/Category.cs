using System.ComponentModel.DataAnnotations;

namespace ManyToMany_ef.Database.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        //todo kompozicija i book
        public List<BookCategory> BookCategories { get; set; }//tas pats kad butu many2many

    }

}
