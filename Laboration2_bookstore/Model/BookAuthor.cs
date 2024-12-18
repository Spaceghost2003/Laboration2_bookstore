using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration2_bookstore.Model
{
    public class BookAuthor
    {
        public string BookId { get; set; }

        public int AuthorId { get; set; }
        public Book Book { get; set; } = null!;
        public Author Author { get; set; } = null!;
    }
}
