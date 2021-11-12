using System;
using System.Collections.Generic;
using System.Text;
using Week6_Paola_Mocci.Entities;

namespace Week6_Paola_Mocci
{
    public class DbManagerMock : IDbManager
    {

        public static List<Agent> agentList = new List<Agent>()
        {
            new Agent("Paola", "Mocci", "MCCPL88", "A01", 2007),
            new Agent("Francesca", "Pala", "PLFRC88", "A01", 2014),
            new Agent("Andrea", "Sini", "SNNDR82", "A02", 2000),
            new Agent("Francesca", "Collu", "CLLFRC88", "A03", 2013),
            new Agent("Federico", "Massa", "MSSFDR", "A03", 2018)
        };



        public bool AddAgent(Agent agente)
        {
            agentList.Add(agente);

            foreach(var item in agentList)
            {
                if(item.CodiceFiscale== agente.CodiceFiscale)
                {
                    return true;
                }

            }

            return false;

        }

        public List<Agent> GetAll()
        {

            return agentList;

        }

        public List<Agent> GetAllByGeographicArea(string area)
        {
            List<Agent> newAgentList = new List<Agent>();

            foreach(var item in agentList)
            {
                if(item.AreaGeografica== area)
                {
                    newAgentList.Add(item);
                }
            }

            return newAgentList;
        }

        public List<Agent> GetByYearsEqualGreaterThan(int years)
        {

            List<Agent> newAgentList = new List<Agent>();

            foreach (var item in agentList)
            {
                if (DateTime.Now.Year - item.AnnoInizioAttivita >= years)
                {
                    newAgentList.Add(item);
                }
            }

            return newAgentList;


        }
    }
}
