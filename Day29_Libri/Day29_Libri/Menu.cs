using System;
using System.Collections.Generic;
using System.Text;
using Day29_Libri.Entities;


namespace Day29_Libri
{
    public class Menu
    {
        //private static DbAudioBookManagerMock DbAudioManager = new DbAudioBookManagerMock();
        //private static DbPaperBooksManagerMock DbPaperManager = new DbPaperBooksManagerMock();
        
        private static DbAudioBookManager DbAudioManager = new DbAudioBookManager();
        private static DbPaperBookManager DbPaperManager = new DbPaperBookManager();


        public static void Start()
        {



            bool goingOn = true;
            while (goingOn)
            {
                Console.WriteLine("\n--------------------------------Menu----------------------------");
                Console.WriteLine("1. Stampa tutti i libri presenti.");
                Console.WriteLine("2. Stampa tutti i libri cartacei.");
                Console.WriteLine("3. Stampa tutti gli audiolibri.");
                Console.WriteLine("4. Modifica la quantità di libri cartacei in magazzino.");
                Console.WriteLine("5. Modifica la durata in minuti di un audiolibro.");
                Console.WriteLine("6. Cercare per titolo tutti i libri.");
                Console.WriteLine("7. Inserisci un nuovo libro.");
                Console.WriteLine("0. Exit");


                int choice;
                do
                {
                    Console.WriteLine("\nScegli cosa fare!\n");
                } while (!(int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice <= 7));

                switch (choice)
                {
                    case 1:

                        GetAllBooks();

                        break;

                    case 2:

                        GetAllPaperBooks();


                        break;

                    case 3:

                        GetAllAudioBooks();


                        break;


                    case 4:

                        ModifyQuantity();


                        break;


                    case 5:

                        ModifyDuration();

                        break;


                    case 6:

                        GetByTitle();

                        break;

                    case 7:

                        InsertBook();

                        break;
                    case 0:
                        goingOn = false;
                        break;

                }


            }
        }

        private static void InsertBook()
        {

            Console.WriteLine("\nPremere:\n" +
                "1. Per aggiungere un libro cartaceo.\n" +
                "2. Per aggiungere un audiolibro.");

            int choice;
            do
            {
                Console.WriteLine("\nScegli cosa fare!\n");
            } while (!(int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 2));

            switch (choice)
            {
                case 1:
                    int id, numPagine, quantita;
                    string titolo, autore, codice;

                    //do
                    //{
                    //    Console.WriteLine("\nInserire Id:\n");
                    //} while (!(int.TryParse(Console.ReadLine(), out id)));

                    Console.WriteLine("\nInserire Titolo:\n");
                    titolo = Console.ReadLine();

                    Console.WriteLine("\nInserire Autore:\n");
                    autore =  Console.ReadLine();

                    Console.WriteLine("\nInserire codice ISBN:\n");
                    codice = Console.ReadLine();

                    do
                    {
                        Console.WriteLine("\nInserire numero di pagine:\n");
                    } while (!(int.TryParse(Console.ReadLine(), out numPagine)));

                    do
                    {
                        Console.WriteLine("\nInserire quantità:\n");
                    } while (!(int.TryParse(Console.ReadLine(), out quantita)));

                   // PaperBook paperBook = new PaperBook(id, titolo, autore, codice, numPagine, quantita);

                    PaperBook paperBook = new PaperBook(titolo, autore, codice, numPagine, quantita);

                    bool isAdded = DbPaperManager.InsertBook(paperBook);

                    if(isAdded== true)
                    {
                        Console.WriteLine("\nIl libro è stato aggiunto correttamente!\n");
                    }
                    else
                    {
                        Console.WriteLine("\nL'aggiunta non è andata a buon fine.\n");
                    }
            


                    break;

                case 2:

                    int idA, durata;
                    string titoloA, autoreA, codiceA;

                    //do
                    //{
                    //    Console.WriteLine("\nInserire Id:\n");
                    //} while (!(int.TryParse(Console.ReadLine(), out idA)));

                    Console.WriteLine("\nInserire Titolo:\n");
                    titoloA = Console.ReadLine();

                    Console.WriteLine("\nInserire Autore:\n");
                    autoreA = Console.ReadLine();

                    Console.WriteLine("\nInserire codice ISBN:\n");
                    codiceA = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("\nInserire la durata:\n");
                    } while (!(int.TryParse(Console.ReadLine(), out durata)));

                    //AudioBook audioBook = new AudioBook(idA, titoloA, autoreA, codiceA, durata);
                    AudioBook audioBook = new AudioBook(titoloA, autoreA, codiceA, durata);

                    bool isAddedA = DbAudioManager.InsertBook(audioBook);

                    if (isAddedA == true)
                    {
                        Console.WriteLine("\nL'audiolibro è stato aggiunto correttamente!\n");
                    }
                    else
                    {
                        Console.WriteLine("\nL'aggiunta non è andata a buon fine.\n");
                    }



                    break;




                    break;
            }




        }

        private static void GetByTitle()
        {
            string title;

            Console.WriteLine("\nDigitare il titolo del libro che si vuole cercare:\n");

            title = Console.ReadLine();


            AudioBook audioBook = DbAudioManager.GetByTitle(title);
            PaperBook paperBook = DbPaperManager.GetByTitle(title);

            if (audioBook != null)
            {
                Console.WriteLine($"\n L'audiolibro trovato è il seguente:\n ");
                Console.WriteLine(audioBook.ToString());
            }
            else
            {
                Console.WriteLine("Non sono stati trovati audiolibri con questo titolo.\n");
            }

            if (paperBook != null)
            {
                Console.WriteLine($"\n Il libro cartaceo trovato è il seguente:\n ");
                Console.WriteLine(paperBook.ToString());

            }
            else
            {
                Console.WriteLine("Non sono stati trovati libri cartacei con questo titolo.\n");
            }


        }

        private static void ModifyDuration()
        {
            int duration;
            int id;

            do
            {
                Console.WriteLine("\nDigitare Id dell'audiolibro del quale si vuole modificare la durata:\n");
            }
            while (!(int.TryParse(Console.ReadLine(), out id)));


            do
            {
                Console.WriteLine("\nDigitare la nuova durata:\n");
            }
            while (!(int.TryParse(Console.ReadLine(), out duration)));

            bool isChanged = DbAudioManager.ModifyDuration(id, duration);

            if (isChanged == true)
            {
                Console.WriteLine("\nLa modifica è avvenuta correttamente!\n");
            }
            else
            {
                Console.WriteLine("\nLa modifica non è andata a buon fine.\n");
            }
        }

        private static void GetAllAudioBooks()
        {
            Console.WriteLine("\nTutti gli audiolibri presenti nella biblioteca sono:\n");
            List<AudioBook> audioBooks = DbAudioManager.GetAllBooks();

            foreach (var item in audioBooks)
            {
                Console.WriteLine(item.ToString());

            }
        }

        private static void GetAllPaperBooks()
        {
            Console.WriteLine("\nTutti i libri cartacei presenti nella biblioteca sono:\n");
            List<PaperBook> paperBooks = DbPaperManager.GetAllBooks();

            foreach (var item in paperBooks)
            {
                Console.WriteLine(item.ToString());

            }
        }

        private static void GetAllBooks()
        {
            Console.WriteLine("\nTutti i libri presenti nella biblioteca sono:\n");
            List<AudioBook> audioBooks = DbAudioManager.GetAllBooks();
            List<PaperBook> paperBooks = DbPaperManager.GetAllBooks();

            List<Book> booksList = new List<Book>();
            booksList.AddRange(paperBooks);
            booksList.AddRange(audioBooks);

            foreach (var item in booksList)
            {
                Console.WriteLine(item.ToString());

            }

        }

        private static void ModifyQuantity()
        {

            int quantity;
            int id;

            do
            {
                Console.WriteLine("\nDigitare Id del libro del quale si vuole modificare la quantità di libri in magazzino:\n");
            }
            while (!(int.TryParse(Console.ReadLine(), out id)));


            do
            {
                Console.WriteLine("\nDigitare la nuova quantità:\n");
            }
            while (!(int.TryParse(Console.ReadLine(), out quantity)));

            bool isChanged = DbPaperManager.ModifyQuantity(id, quantity);

            if (isChanged == true)
            {
                Console.WriteLine("\nLa modifica è avvenuta correttamente!\n");
            }
            else
            {
                Console.WriteLine("\nLa modifica non è andata a buon fine.\n");
            }

        }









    }

}