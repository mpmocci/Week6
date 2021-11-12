using System;
using System.Collections.Generic;
using System.Text;

namespace FigureGeometriche
{
    public class Rettangolo : Forma
    {

        public double Lato1 { get; set; }
        public double Lato2 { get; set; }


        public Rettangolo(string nome, double lato1, double lato2) : base(nome)
        {
            Lato1 = lato1;
            Lato2 = lato2;
        }

        public override double CalcolaArea()
        {
            return Lato1*Lato2;

        }

        public override double CalcolaPerimetro()
        {
            return (Lato1*2)+(Lato2*2) ;
        }
    }


}
