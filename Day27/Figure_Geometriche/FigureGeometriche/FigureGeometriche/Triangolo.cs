using System;
using System.Collections.Generic;
using System.Text;

namespace FigureGeometriche
{
   public class Triangolo : Forma
    {
        public double  Lato1 { get; set; }
        public double  Lato2 { get; set; }
        public double  Lato3 { get; set; }
        public double  Altezza { get; set; }

        public Triangolo(string nome, double lato1, double lato2, double lato3, double altezza) : base(nome) 
        {
            Altezza = altezza;
            Lato1 = lato1;
            Lato2 = lato2;
            Lato3 = lato3;
        }



        public override double CalcolaArea()
        {
            return (Lato1 * Altezza)/2;

        }

        public override double CalcolaPerimetro()
        {
            return Lato1+Lato2+Lato3;
        }

    }
}
