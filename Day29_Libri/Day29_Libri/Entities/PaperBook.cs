using System;
using System.Collections.Generic;
using System.Text;

namespace Day29_Libri.Entities
{
    public class PaperBook: Book
    {

        public int NumeroPagine { get; set; }
        public int QuantitaMagazzino { get; set; }

        public PaperBook(int bookId, string titolo, string autore, string codiceISBN, int numeroPagine, int quantitaMagazzino) : base(bookId, titolo, autore, codiceISBN)
        {
            NumeroPagine = numeroPagine;
            QuantitaMagazzino = quantitaMagazzino;
        }



        public PaperBook(string titolo, string autore, string codiceISBN, int numeroPagine, int quantitaMagazzino) : base(titolo, autore, codiceISBN)
        {
            NumeroPagine = numeroPagine;
            QuantitaMagazzino = quantitaMagazzino;
        }
        public PaperBook()
        {

        }
     
        public override string ToString()
        {
            return $"{BookId} - Titolo: {Titolo} - Autore: {Autore} - Codice ISBN:  {CodiceISBN} - Numero di pagine: {NumeroPagine} - Quantità: {QuantitaMagazzino}";
        }

    }
}
