using System;
using System.Collections.Generic;

namespace Calcio

{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Calcio");
            List<Calciatore> squadra1 = new List<Calciatore>();

            Portiere p = new Portiere("Antonio", "Donnarumma", 20);
            Calciatore d1 = new Calciatore("Alessio", "Romagnoli", 22, 13, Ruolo.Difensore);
            Calciatore c1 = new Calciatore("Sandro", "Tonali", 30, 8, Ruolo.Centrocampista);
            Calciatore a = new Calciatore("Daniel", "Maldini", 25, 20, Ruolo.Attaccante);


            SquadraManager.AddCalciatore(p, squadra1);
            SquadraManager.AddCalciatore(d1, squadra1);
            SquadraManager.AddCalciatore(c1, squadra1);
            SquadraManager.AddCalciatore(a, squadra1);

            Console.WriteLine("La formazione della squadra1 è:\n");

            foreach (var item in squadra1)
            {
                Console.WriteLine(item.ToString());
            }


        }
    }
}
