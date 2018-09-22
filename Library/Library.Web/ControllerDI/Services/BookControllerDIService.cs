using Library.Models;
using Library.Web.ControllerDI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.ControllerDI.Services
{
    public class BookControllerDIService : IBookControllerDI
    {
        public List<Book> list
        {
            get
            {
                var list = new List<Book>
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
                            Id = 1,
                            Name = "Political fiction"
                        }
                    }
                };
                return list;
            }
        }

       
    }
}
