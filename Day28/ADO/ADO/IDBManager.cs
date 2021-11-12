using System;
using System.Collections.Generic;
using System.Text;

namespace ADO
{
  public interface IDBManager
    {
        public void GetAllFilm();
        public void GetFilmByTitolo(string titolo);
        public void GetFilmByGenere(string genere);
        public void GetFilmByDurataMax(int durataMax);
        public void GetFilmByGenereEDurataMin(string genere,int durataMin);
        public void GetNumeroDiFilm();
        public void InserisciFlm(string title, string genre, int length);
        public void ModificaDurataFilm(int idFilmDaModificare, int NewDurata);
        public void EliminaFilm(int idFilmDaEliminare);


    }
}
