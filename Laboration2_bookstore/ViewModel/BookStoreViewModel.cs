using Laboration2_bookstore.Command;
using Laboration2_bookstore.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Laboration2_bookstore.BookstoreContext;
using System.Reflection.Metadata;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;
using static System.Reflection.Metadata.BlobBuilder;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

namespace Laboration2_bookstore.ViewModel
{
    public class BookStoreViewModel : ViewModelBase
    {
        /* ---------------------------TO DO------------------------------ 

         1. Skapa en wrapper



        ----------------------------------------------------------------- */

        public RelayCommand UpdateInventoryCommand { get; }
        private ObservableCollection<Book> _myBooks { get; set; }
        public ObservableCollection<Book> MyBooks
        {
            get { return _myBooks; }
            set
            {
                _myBooks = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Author> _myAuthors;

        public ObservableCollection<Author> MyAuthors
        {
            get { return _myAuthors; }
            set
            {
                _myAuthors = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<BookAuthorDTO> _myBookAuthor;

        public ObservableCollection<BookAuthorDTO> MyBookAuthor
        {
            get { return _myBookAuthor; }
            set {
                _myBookAuthor = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Inventory> _myInventory;

        public ObservableCollection<Inventory> MyInventory
        {
            get { return _myInventory; }
            set
            {
                _myInventory = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<InventoryManager> _myInventoryManager;

        public ObservableCollection<InventoryManager> MyInventoryManager
        {
            get { return _myInventoryManager; }
            set
            {
                _myInventoryManager = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<Store> _myStores;

        public ObservableCollection<Store> MyStores
        {
            get { return _myStores; }
            set
            {
                _myStores = value;
                OnPropertyChanged();
            }
        }

        private Store _selectedStore;

        public Store SelectedStore
        {
            get => _selectedStore;
            set
            {
                _selectedStore = value;
                OnPropertyChanged();

            }
        }

        private InventoryManager _selectedIsbn;

        public InventoryManager SelectedIsbn
        {
            get { return _selectedIsbn; }
            set {
                _selectedIsbn = value;
                OnPropertyChanged();
            }
        }





        public BookStoreViewModel()
        {
            using var context = new BookStoreContext();
            MyStores = GetAllStores();

            if (SelectedStore == null)
            {
                SelectedStore = MyStores[1];
            }

            MyInventoryManager = GetManager(SelectedStore,context);

            UpdateInventoryCommand = new RelayCommand(updateInv);
            //UpdateInventoryAmmount(SelectedStore.Id, SelectedIsbn.ISBN13, 3);


            /* if (SelectedStore != null)
             {
                 MyInventoryManager = new ObservableCollection<InventoryManager>(
                     from stuff in GetInventoryManager(MyBooks, MyAuthors, MyStores, MyInventory)
                     where stuff.StoreName == SelectedStore.Name
                     select stuff);
                 MyInventoryManager = (ObservableCollection<InventoryManager>)(from stuff in
                                         GetInventoryManager(MyBooks, MyAuthors, MyStores, MyInventory)
                                                                               where stuff.StoreName
                                                                               == SelectedStore.Name
                                                                               select stuff);

             }else if(SelectedStore == null)
             {
                 MyInventoryManager = GetInventoryManager(MyBooks, MyAuthors, MyStores, MyInventory);

             }*/

        }

        /*        public static ObservableCollection<InventoryManager> GetManager(Store store)
                {
                    var books = new ObservableCollection<Book>();
                    var authors = new ObservableCollection<Author>();
                    var stores = new ObservableCollection<Store>();
                    var inventory = new ObservableCollection<Inventory>();


                    using var context = new BookStoreContext();

                    var bookQuery = context.Books;
                    var authorQuery = context.Authors;
                    var storeQuery = context.Stores;
                    var inventoryQuery = context.Inventories;

                    bookQuery.ToList();
                    storeQuery.ToList();
                    authorQuery.ToList();
                    inventoryQuery.ToList();
                    ObservableCollection<Book> AllBooks = new ObservableCollection<Book>(bookQuery);
                    ObservableCollection<Author> AllAuthors = new ObservableCollection<Author>(authorQuery);
                    ObservableCollection<Store> AllStores = new ObservableCollection<Store>(storeQuery);
                    ObservableCollection<Inventory> AllInventory = new ObservableCollection<Inventory>(inventoryQuery);

                    var dtos = AllInventory

                    .Join(AllBooks,
                          inventory => inventory.StoreId,
                          book => book.AuthorId,
                          (inventory, book) => new { inventory, book })
                    .Join(AllAuthors,
                          combined => combined.book.AuthorId,
                          author => author.Id,
                          (combined, author) => new { combined.inventory, combined.book, author })
                    .Join(AllStores,
                          combined => combined.inventory.StoreId,
                          store => store.Id,
                          (combined, store) => new InventoryManager
                          {
                              Id = combined.inventory.StoreId,
                              Ammount = combined.inventory.Ammount,
                              AuthorId = combined.author.Id,
                              FirstName = combined.author.FirstName,
                              LastName = combined.author.LastName,
                              ISBN13 = combined.book.Isbn13,
                              Title = combined.book.Title,
                              BookAuthorId = combined.book.AuthorId,
                              StoreId = store.Id,
                              StoreName = store.Name
                          }).Distinct();

                    ObservableCollection<InventoryManager> inventoryManager = new ObservableCollection<InventoryManager>(dtos);
                    return inventoryManager;
                }*/

        static void updateInv(object obj)
        {
              UpdateInventoryAmmount(2, "9780060850524", 3);

        }
        public static ObservableCollection<InventoryManager> GetManager(Store store,BookStoreContext context)
        {
            var books = new ObservableCollection<Book>();
            var authors = new ObservableCollection<Author>();
            var stores = new ObservableCollection<Store>();
            var inventory = new ObservableCollection<Inventory>();

            

            var bookQuery = context.Books;
            var authorQuery = context.Authors;
            var storeQuery = context.Stores;
            var inventoryQuery = context.Inventories;

            ObservableCollection<Book> AllBooks = new ObservableCollection<Book>(bookQuery.ToList());
            ObservableCollection<Author> AllAuthors = new ObservableCollection<Author>(authorQuery.ToList());
            ObservableCollection<Store> AllStores = new ObservableCollection<Store>(storeQuery.ToList());
            ObservableCollection<Inventory> AllInventory = new ObservableCollection<Inventory>(inventoryQuery.ToList());


            var dtos = AllInventory
                .Join(AllBooks,
                      inventory => inventory.Isbn, // Match inventory to book using BookId
                      book => book.Isbn13,
                      (inventory, book) => new { inventory, book })
                .Join(AllAuthors,
                      combined => combined.book.AuthorId,
                      author => author.Id,
                      (combined, author) => new { combined.inventory, combined.book, author })
                .Join(AllStores,
                      combined => combined.inventory.StoreId,
                      store => store.Id,
                      (combined, store) => new { combined.inventory, combined.book, combined.author, store })
                // Filter for the specific store
                .Where(result => result.store.Id == store.Id)
                .Select(result => new InventoryManager
                {
                    Id = result.inventory.StoreId,
                    Ammount = result.inventory.Ammount,
                    AuthorId = result.author.Id,
                    FirstName = result.author.FirstName,
                    LastName = result.author.LastName,
                    ISBN13 = result.book.Isbn13,
                    Title = result.book.Title,
                    BookAuthorId = result.book.AuthorId,
                    StoreId = result.store.Id,
                    StoreName = result.store.Name
                })
                .Distinct();

            ObservableCollection<InventoryManager> inventoryManager = new ObservableCollection<InventoryManager>(dtos);

            return inventoryManager;
        }


        public static void UpdateInventoryAmmount(int storeId, string isbn, int amountChange)
        {
            using var context = new BookStoreContext();

            // Find the inventory entry for the specific book and store
            var inventory = context.Inventories.FirstOrDefault(
                i => i.StoreId == storeId && i.Isbn == isbn);

            if (inventory != null)
            {
                // Update the Ammount field
                inventory.Ammount += amountChange;

                // Ensure the amount does not drop below zero
                if (inventory.Ammount < 0)
                    inventory.Ammount = 0;

                // Save changes to the database
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    // Handle concurrency exceptions
                    Console.WriteLine($"DbUpdateConcurrencyException: {ex.Message}");
                }
                catch (DbUpdateException ex)
                {
                    // Handle database update exceptions
                    Console.WriteLine($"DbUpdateException: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                context.SaveChanges();
            }
            else
            {
                // Optionally handle the case where no inventory exists for the given book and store
                Console.WriteLine("Inventory not found for the specified store and book.");
            }
        }










        static ObservableCollection<Store> GetAllStores()
        {
            var stores = new ObservableCollection<Store>();
            using var context = new BookStoreContext();

            var query = context.Stores;

             query.ToList();

            ObservableCollection<Store> AllStores = new ObservableCollection<Store>(query);

            return AllStores;
        }



/*        static ObservableCollection<BookAuthorDTO> GetBooksAndAuthor(ObservableCollection<Book> books, ObservableCollection<Author> authors)
        {
            using var context = new BookStoreContext();
            var result = context.Books
             .Join(context.Authors,
            book => book.AuthorId,
            author => author.Id,
            (book, author) => new BookAuthorDTO
            {
                Isbn13 = book.Isbn13,
                Title = book.Title,
                Price = book.Price,
                AuthorName = $"{author.FirstName} {author.LastName}",
                Birthdate = author.Birthdate,
                AuthorID = author.Id
            })
            .ToList();

            ObservableCollection < BookAuthorDTO > bookAuthorCollection = new ObservableCollection<BookAuthorDTO>(result);

            return bookAuthorCollection;
        }*/



        public IEnumerable<InventoryManager> GetInventoryManager(IEnumerable<Book> books, IEnumerable<Author> authors, IEnumerable<Store> stores, IEnumerable<Inventory> inventory)
        {
            var inventoryManagers = from book in books
                                    join inv in inventory on book.Isbn13 equals inv.Isbn
                                    join store in stores on inv.StoreId equals store.Id
                                    join author in authors on book.AuthorId equals author.Id
                                    select new InventoryManager
                                    {
                                        StoreId = store.Id,
                                        StoreName = store.Name,
                                        Title = book.Title,
                                        ISBN13 = book.Isbn13,
                                        AuthorId = author.Id,
                                        FirstName = author.FirstName,
                                        LastName = author.LastName,
                                        Ammount = inv.Ammount
                                    };

            var groupedInventoryManagers = from stuff in inventoryManagers
                                           group stuff by new
                                           {
                                               stuff.StoreName,
                                               stuff.Title,
                                               stuff.ISBN13,
                                               stuff.AuthorId,
                                               stuff.FirstName,
                                               stuff.LastName,
                                               stuff.StoreId
                                           } into bookGroup
                                           select new InventoryManager
                                           {
                                               StoreId = bookGroup.Key.StoreId,
                                               StoreName = bookGroup.Key.StoreName,
                                               Title = bookGroup.Key.Title,
                                               ISBN13 = bookGroup.Key.ISBN13,
                                               AuthorId = bookGroup.Key.AuthorId,
                                               FirstName = bookGroup.Key.FirstName,
                                               LastName = bookGroup.Key.LastName,
                                               Ammount = bookGroup.Sum(x => x.Ammount)
                                           };

            return groupedInventoryManagers;
        }


      /*  static ObservableCollection<InventoryManager> GetInventoryManager(
            ObservableCollection<Book> books,
            ObservableCollection<Author> authors,
            ObservableCollection<Store> stores,
            ObservableCollection<Inventory> inventories
            ) 
        {//testing this


            var dtos = inventories
                        .Join(books,
                              inventory => inventory.StoreId,
                              book => book.AuthorId,
                              (inventory, book) => new { inventory, book })
                        .Join(authors,
                              combined => combined.book.AuthorId,
                              author => author.Id,
                              (combined, author) => new { combined.inventory, combined.book, author })
                        .Join(stores,
                              combined => combined.inventory.StoreId,
                              store => store.Id,
                              (combined, store) => new InventoryManager
                              {
                                  Id = combined.inventory.StoreId,
                                  Ammount = combined.inventory.Ammount,
                                  AuthorId = combined.author.Id,
                                  FirstName = combined.author.FirstName,
                                  LastName = combined.author.LastName,
                                  ISBN13 = combined.book.Isbn13,
                                  Title = combined.book.Title,
                                  BookAuthorId = combined.book.AuthorId,
                                  StoreId = store.Id,
                                  StoreName = store.Name
                              }).Distinct();

            ObservableCollection<InventoryManager> inventoryManager = new ObservableCollection<InventoryManager>(dtos);
            return inventoryManager;
        }*/


        //static void GetInventory(ObservableCollection<BookAuthorDTO> bookAuthors)
        //{
        //    var authors = new ObservableCollection<Author>();
        //    using var context = new BookStoreContext();
        //    var query = context.Authors;
        //    query.ToList();

        //    ObservableCollection<BookAuthor> AllAuthors = new ObservableCollection<BookAuthor>(query);

        //    return AllAuthors;
        //}
    }
}
