using Library.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Repositories
{
    public class BooksRepository
    {
        private static List<Book> _allBooks = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Myśli współczesnego człowieka",
                Author = "Roman Dmowski",
                ProductionYear = 1920,
                Genre = new Genre
                {
                    Id = 1,
                    Name = "Political fiction"
                }
            },
            new Book
            {
                Id = 1,
                Title = "Czerwona książeczka",
                Author = "Mao Ze Dung",
                ProductionYear = 1925,
                Genre = new Genre
                {
                    Id = 2,
                    Name = "Political fiction"
                }
            }
        };
        public List<Book> GetBooks()
        {
            using(var context = new LibraryContext())
            {
                return context.Book.Include(x => x.Genre).ToList();
            }
        }

        public Book GetBookById(int id)
        {
            using (var context = new LibraryContext())
            {
                return context.Book.Where(x => x.Id == id).Include(x => x.Genre).Single();
            }
        }
        
        public int AddBook(Book book)
        {
            var maxId = _allBooks.Select(x => x.Id).Max();
            book.Id = maxId + 1;
            var genreRepository = new GenreRepository();
            book.Genre = genreRepository.Get(book.GenreId);

            _allBooks.Add(book);

            return book.Id;
        }

        public int EditBook(int id, Book book)
        {
            var bookIndex =_allBooks.FindIndex(x => x.Id == id);
            var genreRepository = new GenreRepository();
            book.Genre = genreRepository.Get(book.GenreId);

            _allBooks[bookIndex] = book;
            return book.Id;
        }

        public List<Book> DeleteBook(int id)
        {
            var bookIndex = _allBooks.FindIndex(x => x.Id == id);
            _allBooks.RemoveAt(bookIndex);
            return _allBooks;
        }

        public object GetBookByGenreId(int value)
        {
            return _allBooks.FirstOrDefault(x => x.Genre.Id == value);
        }
    }
}
