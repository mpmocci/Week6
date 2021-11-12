using System;
using System.Collections.Generic;
using System.Text;

namespace FigureGeometriche
{
    public class Quadrato : Rettangolo
    {

        public double Lato { get; set; }

        public Quadrato(string nome, double lato1, double lato2): base(nome, lato1, lato1)
        {
            Lato = lato1;
        }


        public override double CalcolaArea()
        {
            return Lato * Lato;

        }

        public override double CalcolaPerimetro()
        {
            return Lato*4;
        }




    }
}
