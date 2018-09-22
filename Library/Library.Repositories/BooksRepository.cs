using Library.Models;
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
                PublishYear = 1920,
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
                PublishYear = 1925,
                Genre = new Genre
                {
                    Id = 2,
                    Name = "Political fiction"
                }
            }
        };
        public List<Book> GetBooks()
        {
            return _allBooks;
        }

        public Book GetBookById(int id)
        {
            return _allBooks.FirstOrDefault(x => x.Id == id);
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
            return _allBooks.FirstOrDefault(x => x.GenreId == value);
        }
    }
}
