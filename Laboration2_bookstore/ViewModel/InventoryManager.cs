using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laboration2_bookstore.ViewModel
{
    public class InventoryManager
    {

        /* 
         Inventory:
                STOREID
                AMMOUNT
                
           BookAuthor:
                ID
                AuthorName
                
            Book:
                Title
                ISBN13
                AuthorID
            Store:
                ID
                Name
                
         
         
         */

        /*        //-----------INVENTORY-------------
                public int? Id { get; set; }
                public int Ammount { get; set; }

                //-----------AUTHOR-----------------
                 public int AuthorId { get; set; }
                 public string FirstName { get; set; }

                 public string LastName { get; set; }


                //------------BOOK-----------------
                public string ISBN13 { get; set; }

                public string Title { get; set; }

                public int BookAuthorId { get; set; }

                //-----------STORE------------------

                public int StoreId { get; set; }

                public int StoreName { get; set; }*/



        public int? Id { get; set; }
        public int? Ammount { get; set; }
        public int? AuthorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ISBN13 { get; set; }
        public string? Title { get; set; }
        public int? BookAuthorId { get; set; }
        public int? StoreId { get; set; }
        public string? StoreName { get; set; }
    }
}
