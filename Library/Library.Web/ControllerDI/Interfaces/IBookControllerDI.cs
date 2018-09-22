using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.ControllerDI.Interfaces
{
    public interface IBookControllerDI
    {
        List<Book> list{get;}
    }
}
