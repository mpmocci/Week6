using System;
using System.Collections.Generic;
using System.Text;

namespace Day29_Libri.Entities
{
    public class AudioBook : Book
    {

        public int Durata { get; set; }

        public AudioBook(int bookId, string titolo, string autore, string codiceISBN, int durata) : base( bookId, titolo, autore, codiceISBN)
        {
            Durata = durata;
        }

        public AudioBook(string titolo, string autore, string codiceISBN, int durata) : base(titolo, autore, codiceISBN)
        {
            Durata = durata;
        }

        public AudioBook()
        {

        }
        public override string ToString()
        {
            return $"{BookId} - Titolo: {Titolo} - Autore: {Autore} - Codice ISBN: {CodiceISBN} - Durata: {Durata}";

        }
    }
}
