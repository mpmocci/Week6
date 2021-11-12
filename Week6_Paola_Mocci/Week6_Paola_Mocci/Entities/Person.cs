using System;
using System.Collections.Generic;
using System.Text;

namespace Week6_Paola_Mocci.Entities
{
   public abstract class Person
    {

        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }


        public Person(string codiceFiscale, string nome, string cognome ) 
        {
            CodiceFiscale = codiceFiscale;
            Nome = nome;
            Cognome = cognome;
        }

    }
}
