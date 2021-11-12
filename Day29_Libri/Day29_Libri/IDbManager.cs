using System;
using System.Collections.Generic;
using System.Text;
using Day29_Libri.Entities;


namespace Day29_Libri
{
    interface IDbManager<T>
    {

        public List<T> GetAllBooks();
        public T GetByTitle(string title);
        public abstract bool InsertBook(T item);

    }
}
