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

namespace Laboration2_bookstore.ViewModel
{
    public class BookStoreViewModel :ViewModelBase
    {
       /* ---------------------------TO DO------------------------------ 
        
        1. Skapa en wrapper
        
        
        
       ----------------------------------------------------------------- */

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

        private ObservableCollection<BookAuthorDTO> _myBookAuthor ;

        public ObservableCollection<BookAuthorDTO> MyBookAuthor
        {
            get { return _myBookAuthor; }
            set { 
                _myBookAuthor= value;
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
            get { return _selectedStore; }
            set 
            { 
                _selectedStore = value;
                OnPropertyChanged();
            }
        }




        public BookStoreViewModel()
        {
            MyStores = GetAllStores();
            MyBooks = GetAllBooks(true);
            MyAuthors = GetAllAuthors();
            MyBookAuthor = GetBooksAndAuthor(MyBooks, MyAuthors);

        }
        static ObservableCollection<Book> GetAllBooks(bool printSQL = false)
        {
            var books = new ObservableCollection<Book>();
            using var context = new BookStoreContext();

            var query = context.Books;

             query.ToList();

            ObservableCollection<Book> AllBooks = new ObservableCollection<Book>(query);

            return AllBooks;
            
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

        static ObservableCollection<Author> GetAllAuthors()
        {
            var authors = new ObservableCollection<Author>();
            using var context = new BookStoreContext();
            var query = context.Authors;
            query.ToList();

            ObservableCollection<Author> AllAuthors = new ObservableCollection<Author>(query);
            
            return AllAuthors;
        }

        static ObservableCollection<BookAuthorDTO> GetBooksAndAuthor(ObservableCollection<Book> books, ObservableCollection<Author> authors)
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
        }

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
