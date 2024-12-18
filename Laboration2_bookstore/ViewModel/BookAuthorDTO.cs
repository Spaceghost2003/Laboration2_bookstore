using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration2_bookstore.ViewModel
{
    public class BookAuthorDTO
    {
        public string Isbn13 { get; set; }
        public string? Title { get; set; }
        public double? Price { get; set; }
        public string AuthorName { get; set; }
        public DateOnly? Birthdate { get; set; }

        public int? AuthorID { get; set; }
    }
}
