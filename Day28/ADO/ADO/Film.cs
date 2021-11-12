using System;
using System.Collections.Generic;
using System.Text;

namespace ADO
{
   public class Film
    {
        public int FilmId { get; set; }
        public string Titolo { get; set; }
        public string Genere { get; set; }
        public int Durata { get; set; }

        public override string ToString()
        {
            return $"{FilmId} - {Titolo} - {Durata} - {Genere}";
        }



    }


   

}
