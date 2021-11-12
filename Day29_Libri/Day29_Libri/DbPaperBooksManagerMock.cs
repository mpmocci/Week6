using Day29_Libri.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day29_Libri
{
    public class DbPaperBooksManagerMock : IDbManagerPaperBook
    {
        public static List<PaperBook> paperBooks = new List<PaperBook>()
        {
            new PaperBook( 1, "Chourmo", "Jean-Claude Izzo", "A111", 100, 14 ),
            new PaperBook(2,  "Solea", "Jean-Claude Izzo",  "A112",  150, 40),
            new PaperBook(3,  "I fratelli Karamazov", "Dostoevskij",  "A113",  600, 12 )
        };


        public List<PaperBook> GetAllBooks()
        {
            return paperBooks;
        }

        public PaperBook GetByTitle(string title)
        {
            PaperBook paperBook = new PaperBook();

            foreach (var item in paperBooks)
            {
                if (item.Titolo == title)
                {
                    return item;
                }
            }

            return null;
        }

        public bool InsertBook(PaperBook book)
        {
            bool isAdded = false;
            paperBooks.Add(book);

            foreach (var item in paperBooks)
            {
                if (item.BookId == book.BookId)
                {
                    isAdded = true;
                }
            }

            return isAdded;
        }

        public bool ModifyQuantity(int id, int quantity)
        {
            bool isChanged = false;

            foreach (var item in paperBooks)
            {
                if(item.BookId == id)
                {
                    item.QuantitaMagazzino = quantity;
                    isChanged = true;
                }
              
            }

            return isChanged;
        }
    }

   
}
