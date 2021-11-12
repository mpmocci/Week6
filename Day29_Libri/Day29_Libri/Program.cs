using System;
using Day29_Libri.Entities;

namespace Day29_Libri
{
    class Program
    {

        // Creare un programma per la gestione di libri da parte del proprietario del sito
        // I libri hanno titolo - autore - codice ISBN -> abstract
        // Gli audiolibri hanno anche la durata in minuti
        // I libri cartacei hanno il numero di pagine e la quantità in magazzino

        // Il proprietario può vedere tutti i libri stampando titolo, autore e se è o no audiolibro
        // vedere tutta la lista di libri cartacei
        // vedere tutta la lista di audiolibri
        // Modificare la quantità di libri cartacei in magazzino
        // Modificare la durata in minuti di un audiolibro
        // Cercare per titolo tutti i film (Se inserisce un titolo gli viene mostrato sia il libro cartaceo che l'audiolibro)
        //Puo inserire un nuovo libro cartaceo o audiolibro
        // Se inserisce un nuovo libro cartaceo o audiolibro,
        // prima di inserirlo verificare che non sia già presente tramite codice ISBN)
        // due libri sono uguali se hanno lo stesso ISBN( cartecei e audiolibri NON hanno lo stesso ISBN)

        // Gestire il db sia in connected mode che i repository mock
        static void Main(string[] args)
        {

            Menu.Start();


        }
    }
}
