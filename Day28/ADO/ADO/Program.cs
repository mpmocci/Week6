using System;

namespace ADO
{
    class Program
    {

        // L'utente può:
        // Vedere tutti i film nella videoteca
        // Cercere i film per genere
        // Cercare i film per titolo
        // Cercare i film che hanno una durata minore di tot minuti
        // Cercare i film di un genere che hanno anche una durata maggiore di tot minuti
        // Stampare il numeri di film nella videoteca

        // Far scegliere all'utente i soli generi presenti
        // oppure gestire se non trova film con il genere inserito

        static void Main(string[] args)
        {
            //DbManagerMock db = new DbManagerMock();
            DbManager db = new DbManager();


            Console.WriteLine("Benvenuto nella videoteca!\n");

            bool continua = true;

            while (continua)
            {
                Console.WriteLine("---------------Menù----------------");
                Console.WriteLine("1. Stampa tutti i film della videoteca.");
                Console.WriteLine("2. Cerca film per genere.");
                Console.WriteLine("3. Cerca film per titolo.");
                Console.WriteLine("4. Cerca film che hanno una durata inferiore a tot minuti.");
                Console.WriteLine("5. Cerca film di un genere che hanno anche una durata maggiore a tot minuti.");
                Console.WriteLine("6. Stampa numero di film.");
                Console.WriteLine("7. Inserisci un nuovo film.");
                Console.WriteLine("8. Modifica durata di un  film.");
                Console.WriteLine("9. Elimina un  film.");
                Console.WriteLine("0. Exit");

                int scelta;

                do
                {
                    Console.WriteLine("Fai la tua scelta.");
                }
                while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 9));



                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("I film presenti nella videoteca sono: \n");
                        db.GetAllFilm();

                        break;

                    case 2:

                        Console.WriteLine("Inserisci genere da ricercare: \n");

                        string genereScelto = Console.ReadLine();

                        db.GetFilmByGenere(genereScelto);

                        break;

                    case 3:
                        Console.WriteLine("Inserisci titolo da ricercare: \n");

                        string titolo = Console.ReadLine();

                        db.GetFilmByTitolo(titolo);

                        break;

                    case 4:
                        int durata;
                        do
                        {
                            Console.WriteLine("Inserisci la durata massima: \n");
                        }
                        while (!(int.TryParse(Console.ReadLine(), out durata) && durata >0));

                        db.GetFilmByDurataMax(scelta);


                        break;

                    case 5:
                        Console.WriteLine("Inserisci genere da ricercare: \n");

                        string genere = Console.ReadLine();

                        int d;
                        do
                        {
                            Console.WriteLine("Inserisci la durata minima: \n");
                        }
                        while (!(int.TryParse(Console.ReadLine(), out d) && d > 0));

                        db.GetFilmByGenereEDurataMin(genere, d);



                        break;

                    case 6:

                        db.GetNumeroDiFilm();

                            break;


                    case 7:

                        Console.WriteLine("Inserisci il titolo del nuovo film:\n");
                        string title = Console.ReadLine(); 
                        Console.WriteLine("Inserisci il genere del nuovo film:\n");
                        string genre = Console.ReadLine();
                        int length;
                        do
                        {
                            Console.WriteLine("Inserisci la durata del nuovo film:\n");
                        }
                        while (!(int.TryParse(Console.ReadLine(), out length) && length > 0));
                        

                        db.InserisciFilm(title, genre, length);

                        break;




                    case 8:

                        int id, newDurata;
                        do
                        {
                            Console.WriteLine("Inserisci l'ID del film da modificare:\n");
                        }
                        while (!(int.TryParse(Console.ReadLine(), out id)));

                        do
                        {
                            Console.WriteLine("Inserisci la nuova durata del film:\n");
                        }
                        while (!(int.TryParse(Console.ReadLine(), out newDurata)));


                        db.ModificaDurataFilm(id, newDurata);

                        break;             
                    
                    case 9:

                        int id_eliminare;
                        do
                        {
                            Console.WriteLine("Inserisci l'ID del film da modificare:\n");
                        }
                        while (!(int.TryParse(Console.ReadLine(), out id_eliminare)));



                        db.EliminaFilm(id_eliminare);

                        break;


                    case 0:

                        continua = false;
                        break;

                }


            }





            }

    }
    }
