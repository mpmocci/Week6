using System;
using System.Collections.Generic;
using System.Text;

namespace Day29_Libri.Entities
{
    public abstract class Book
    {
        public int BookId { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string CodiceISBN { get; set; }

        public Book(int bookId, string titolo, string autore, string codiceISBN)
        {
            BookId = bookId;
            Titolo = titolo;
            Autore = autore;
            CodiceISBN = codiceISBN;
        }

        public Book(string titolo, string autore, string codiceISBN)
        {
            Titolo = titolo;
            Autore = autore;
            CodiceISBN = codiceISBN;
        }
        public Book()
        {

        }
        public override string ToString()
        {
            return $"{BookId} - Titolo: {Titolo} - Autore: {Autore} - Codice ISBN: {CodiceISBN}";
        }
    }
}
