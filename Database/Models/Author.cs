using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany_ef.Database.Models
{
    public class Author
    {
        [Key]//pirminis raktas
        public int AuthorId { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; }//kompozicija i lentele books
    }

}
