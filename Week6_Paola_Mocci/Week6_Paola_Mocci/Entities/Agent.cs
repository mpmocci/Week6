using System;
using System.Collections.Generic;
using System.Text;

namespace Week6_Paola_Mocci.Entities
{
    public class Agent : Person
    {
        int currentYear= DateTime.Now.Year;

        public string AreaGeografica{ get; set; }
        public int AnnoInizioAttivita { get; set; }

        public Agent(string codiceFiscale, string nome, string cognome, string areaGeografica, int annoInizio) : base(codiceFiscale, nome, cognome)
        {
            AreaGeografica = areaGeografica;
            AnnoInizioAttivita = annoInizio;
        }

        public int CalculateYears()
        {
           return currentYear - AnnoInizioAttivita;
        }

        public override string ToString()
        {
            return $"CF: {CodiceFiscale} - Nome: {Nome} - Cognome: {Cognome} - Anni di servizio: {CalculateYears()}\n";
        }

    }
}
