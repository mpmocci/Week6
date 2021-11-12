using System;
using System.Collections.Generic;
using System.Text;

namespace ADO
{
   public class DbManagerMock : IDBManager     
    {

        static List<Film> Films = new List<Film>() {
        new Film{FilmId=1, Titolo="Titanic", Durata=240, Genere="Storico" },
        new Film{FilmId=2, Titolo="Peter Pan", Durata = 60, Genere="Animazione"}
        };

        public void EliminaFilm(int idFilmDaEliminare)
        {
            throw new NotImplementedException();
        }

        public  void GetAllFilm()
        {
            foreach (var item in Films)
            {
                Console.WriteLine(item.ToString());
            }
        
        
        
        
        }

     

        public  void GetFilmByDurataMax(int durataMax)
        {
            throw new NotImplementedException();
        }

        public  void GetFilmByGenere(string genere)
        {
            foreach (var item in Films)
            {
                if(item.Genere == genere)
                {
                    Console.WriteLine(item.ToString());
                }
            }



        }

        public  void GetFilmByGenereEDurataMin(string genere, int durataMin)
        {
            throw new NotImplementedException();
        }

        public  void GetFilmByTitolo(string titolo)
        {
            throw new NotImplementedException();
        }

        public  void GetNumeroDiFilm()
        {
            throw new NotImplementedException();
        }

        public void InserisciFlm(string title, string genre, int length)
        {
            throw new NotImplementedException();
        }

        public void ModificaDurataFilm(int idFilmDaModificare)
        {
            throw new NotImplementedException();
        }

        public void ModificaDurataFilm(int idFilmDaModificare, int NewDurata)
        {
            throw new NotImplementedException();
        }
    }
}
