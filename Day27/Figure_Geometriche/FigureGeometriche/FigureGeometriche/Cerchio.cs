using System;
using System.Collections.Generic;
using System.Text;

namespace FigureGeometriche
{
   public class Cerchio : Forma
    {
        public double Raggio { get; set; } = 0;

        public Cerchio(string nome, double raggio) : base(nome)
        {
            Raggio = raggio;
        }

        public override double CalcolaArea()
        {
            return 3.14 * (Raggio*Raggio);

        }

        public override double CalcolaPerimetro()
        {
            return 2 * 3.14 * Raggio;
        }
    }
}
