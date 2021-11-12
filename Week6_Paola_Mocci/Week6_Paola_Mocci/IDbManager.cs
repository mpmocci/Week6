using System;
using System.Collections.Generic;
using System.Text;
using Week6_Paola_Mocci.Entities;

namespace Week6_Paola_Mocci
{
    interface IDbManager
    {

        public List<Agent> GetAll();
        public List<Agent> GetAllByGeographicArea(string area);
        public List<Agent> GetByYearsEqualGreaterThan(int years);
        public bool AddAgent(Agent agente);


    }
}
