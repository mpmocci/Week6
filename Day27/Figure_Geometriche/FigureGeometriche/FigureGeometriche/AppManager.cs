using System;
using System.Collections.Generic;
using System.Text;

namespace FigureGeometriche
{
   public static class AppManager
    {

        public static List<Quadrato> quadrati = new List<Quadrato>();
        public static List<Cerchio> cerchi = new List<Cerchio>();
        public static List<Rettangolo> rettangoli = new List<Rettangolo>();
        public  static List<Triangolo> triangoli = new List<Triangolo>();
        public  static List<Forma> forme = new List<Forma>();

        public static void AddTriangle(double[] triangleArray)
        {
            Triangolo triangolo = new Triangolo("Triangolo", triangleArray[0], triangleArray[1], triangleArray[2], triangleArray[3]);
            triangoli.Add(triangolo);
        }

        internal static void AddCircle(ref double radius)
        {
            Cerchio cerchio = new Cerchio("Cerchio", radius);
            cerchi.Add(cerchio);
        }

        internal static void AddSquare(ref double lato)
        {
            Quadrato quadrato = new Quadrato("Quadrato", lato, lato);
            quadrati.Add(quadrato);

        }

        internal static void AddRectangle(double[] rectangleArray)
        {
            Rettangolo rettangolo = new Rettangolo("Rettangolo", rectangleArray[0], rectangleArray[1]);
        }

        internal static void GetList(char choice)
        {
            switch (choice)
            {
                case1
            }



        }
    }
}
