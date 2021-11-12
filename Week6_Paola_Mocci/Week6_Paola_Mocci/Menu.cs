using System;
using System.Collections.Generic;
using System.Text;
using Week6_Paola_Mocci.Entities;

namespace Week6_Paola_Mocci
{
   public class Menu
    {
       //private static DbManager dbManager = new DbManager();
       private static DbManagerMock dbManager = new DbManagerMock();

        public static void Start()
        {

            bool goOn = true;
            while (goOn)
            {
                Console.WriteLine("\n--------------------------------Menu----------------------------");
                Console.WriteLine("1. Mostrare tutti gli agenti di polizia.");
                Console.WriteLine("2. Scelta un'area geografica, mostrare tutti gli agenti assegnati a quell'area.");
                Console.WriteLine("3. Scelti gli anni di servizio, mostrare gli agenti con anni di servizio maggiori o uguali a quelli forniti.");
                Console.WriteLine("4. Inserire un nuovo agente.");
                Console.WriteLine("0. Exit");
                Console.WriteLine("\n------------------------------------------------------------");



                int choice;
                do
                {
                    Console.WriteLine("\nScegli cosa fare!\n");
                } while (!(int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice <= 4));

                switch (choice)
                {
                    case 1:
                        PrintAll();

                        break;

                    case 2:
                        PrintAllByArea();

                        break;

                    case 3:
                        GetByYears();

                        break;

                    case 4:

                        AddAgent();

                        break;

                    case 0:
                        goOn = false;
                        break;

                }

            }
        }

        private static void AddAgent()
        {
            string codice, nome, cognome, area;
            int anno;
            List<Agent> agentList = dbManager.GetAll();
            bool goOn;

            do
            {
                Console.WriteLine("\nDigitare codice fiscale:\n");
                codice = Console.ReadLine();
                goOn = false;
                foreach (var item in agentList)
                {
                    if (item.CodiceFiscale == codice)
                    {
                        goOn = true;
                        Console.WriteLine("\nNel database è già presente un agente con questo codice fiscale.\n");
                    }

                }
            } while (goOn == true);

            Console.WriteLine("\nDigitare nome:\n");
            nome = Console.ReadLine();
            Console.WriteLine("\nDigitare cognome:\n");
            cognome = Console.ReadLine();

            do { 
            Console.WriteLine("\nDigitare area geografica tra le seguenti:\n");
                Console.WriteLine("1. A01, Is Mirrionis");
                Console.WriteLine("2. A02, Pirri");
                Console.WriteLine("3. A03, Barracca Manna");
                Console.WriteLine("4. A04, Is Arenas");

            area = Console.ReadLine();
            } while (!(area == "A01" || area == "A02" || area == "A03" || area == "A04"));


            do
            {
                Console.WriteLine("Digitare anno di inizio attività:\n");
            }
            while (!(int.TryParse(Console.ReadLine(), out anno)));

            Agent agente = new Agent(codice, nome, cognome, area, anno );

            bool isAdded = dbManager.AddAgent(agente);

            if (isAdded == true)
            {
                Console.WriteLine("L'aggiunta è andata a buon fine.\n");
            }
            else
            {
                Console.WriteLine("Si è verificato un errore, agente non aggiunto.");
            }

        }

        private static void GetByYears()
        {
            int years;
            do
            {
                Console.WriteLine("Digitare gli anni di servizio:\n");
            }
            while (!(int.TryParse(Console.ReadLine(), out years) && years>0));

            Console.WriteLine($"\nLa lista di tutti gli agenti di polizia con anni di servizio pari almeno a {years} è la seguente:\n");


            List<Agent> agentList = dbManager.GetByYearsEqualGreaterThan(years);
            int numbList = 1;

            if (agentList.Count == 0)
            {
                Console.WriteLine("\n Non sono presenti agenti assegnati a quest'area geografica.\n");
            }
            else
            {
                foreach (var item in agentList)
                {
                    Console.WriteLine($"{numbList++}. {item.ToString()}");
                }
            }



        }

        private static void PrintAllByArea()
        {
            string area;

            do
            {
                Console.WriteLine("\nScegliere l'area geografica della quale si vogliono visualizzare gli agenti assegnati:\n");
                Console.WriteLine("1. A01, Is Mirrionis");
                Console.WriteLine("2. A02, Pirri");
                Console.WriteLine("3. A03, Barracca Manna");
                Console.WriteLine("4. A04, Is Arenas");
                area = Console.ReadLine();
            } while (!(area == "A01" || area == "A02" || area == "A03" || area == "A04"));

            Console.WriteLine($"\nLa lista di tutti gli agenti di polizia assegnati all'area{area} è la seguente:\n");
           
            
            List<Agent> agentList = dbManager.GetAllByGeographicArea(area);
            int numbList = 1;

            if (agentList.Count == 0)
            {
                Console.WriteLine("\n Non sono presenti agenti assegnati a quest'area geografica.\n");
            }
            else
            {
                foreach (var item in agentList)
            {
                    Console.WriteLine($"{numbList++}. {item.ToString()}");
                }
            }
        }

        private static void PrintAll()
        {
            Console.WriteLine("\nLa lista di tutti gli agenti di polizia presente nel database è la seguente:\n");
            List<Agent> agentList = dbManager.GetAll();
            int numbList = 1;

            foreach (var item in agentList)
            {
                Console.WriteLine($"{numbList++}. {item.ToString()}");
            }
        }








    }



}
