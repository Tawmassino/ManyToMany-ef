namespace ManyToMany_ef.Database.Models
{
    public class BookCategory //many-many jungiamoji lentele
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }


        public Book Book { get; set; }//virtual/navigational  property - naudojami patogumui, uztikrins sarysi,nereiks galvot kaip daryt join
        public Category Category { get; set; }
    }

}
