using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laboration2_bookstore.ViewModel
{
    internal class InventoryManager
    {

        /* 
         Inventory:

           
         
         
         */
        public int? Id { get; set; }

        public string StoreId { get; set; }

        public int Ammount { get; set; }

        public string ISBN13 { get; set; }

        public int AuthorId { get; set; }
    }
}
