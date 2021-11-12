using System;
using System.Collections.Generic;
using System.Text;

namespace FigureGeometriche
{
    public abstract class Forma
    {

        public string Nome { get; set; }


        public Forma(string nome)
        {
            Nome = nome;
        }

        public abstract double CalcolaArea();
        public abstract double CalcolaPerimetro();


        public override string ToString()
        {
            return $"Forma: {Nome} - Area: {CalcolaArea()} - Perimetro: {CalcolaPerimetro()}";
        }
    }
}
