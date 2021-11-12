using Day29_Libri.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day29_Libri
{
    public class DbAudioBookManagerMock : IDbManagerAudioBook
    {

        public static List<AudioBook> audioBooks = new List<AudioBook>(){
            new AudioBook( 1, "Chourmo", "Jean-Claude Izzo", "B111", 240),
            new AudioBook(2,  "LUX", "Eleonora Marangoni",  "B112",  200),
            new AudioBook(3,  "Tremori", "Amelie Nothomb",  "B113",  120 )
            };


        public List<AudioBook> GetAllBooks()
        {
            return audioBooks;
        }

        public AudioBook GetByTitle(string title)
        {

            AudioBook audioBook = new AudioBook();

            foreach (var item in audioBooks)
            {
                if(item.Titolo == title)
                {
                    return item;
                }
            }

            return null;
        }

        public bool InsertBook(AudioBook book)
        {
            bool isAdded = false;
            audioBooks.Add(book);

            foreach (var item in audioBooks)
            {
                if (item.BookId == book.BookId)
                {
                    isAdded = true;
                }
            }

            return isAdded;
        }


        public bool ModifyDuration(int id, int duration)
        {
            bool isChanged = false;

            foreach (var item in audioBooks)
            {
                if (item.BookId == id)
                {
                    item.Durata = duration;
                    isChanged = true;
                }
                
            }

            return isChanged;



        }
    }
}
