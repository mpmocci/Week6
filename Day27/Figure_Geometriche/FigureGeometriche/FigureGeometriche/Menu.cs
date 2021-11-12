using System;
using System.Collections.Generic;
using System.Text;

namespace FigureGeometriche
{
    public static class Menu
    {
        internal static void Start()
        {


            bool exit = true;
            do
            {
                Console.WriteLine("\n * **** Menu *****" +
                "\n[1] Inserisci figure geometriche." +
                "\n[2] Stampa figure geometriche della lista." +
                "\n[3] Stampa area di tutte le figure geometriche della lista." +
                "\n[4] Stampa perimetro di tutte le figure geometriche della lista." +
                "\n[Q] Esci");

                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':

                        AddShapes();

                        break;

                    case '2':

                        PrintLists();


                        break;

                    case '3':



                        break;

                    case '4':



                        break;


                    case 'Q':
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Arrivederci.");
                        break;
                }

            } while (exit);

        }

        private static void PrintLists()
        {


            char choice;
            do
            {

                Console.WriteLine("\nPremi il tasto corrispondente alla figura geometrica della quale vuoi visualizzare la lista:" +
                "\n[1] Triangolo." +
                 "\n[2] Cerchio." +
                 "\n[3] Quadrato." +
                 "\n[4] Rettangolo.");

                choice = Console.ReadKey().KeyChar;

          
            } while (!(choice=='1' || choice=='2'|| choice=='3' ||choice=='4'));

            AppManager.GetList(choice);

        }

        private static void AddShapes()
        {

            bool exit = true;
            do
            {

                Console.WriteLine("\nPremi il tasto corrispondente alla figura geometrica da inserire:" +
                "\n[1] Triangolo." +
                 "\n[2] Cerchio." +
                 "\n[3] Quadrato." +
                 "\n[4] Rettangolo." +
                 "\n[Q] Esci");

                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        double[] triangleArray = new double[4];
                        triangleArray = GetTriangleData();
                        AppManager.AddTriangle(triangleArray);

                        break;

                    case '2':

                        double radius = GetCircleData();
                        AppManager.AddCircle(ref radius);

                        break;

                    case '3':

                        double lato = GetSquareData();
                        AppManager.AddSquare(ref lato);


                        break;

                    case '4':
                        double[] rectangleArray = new double[2];
                        rectangleArray = GetRectangleData();
                        AppManager.AddRectangle(rectangleArray);


                        break;



                    case 'Q':
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Arrivederci.");
                        break;

                }

            } while (exit);





        }

        private static double[] GetRectangleData()
        {
            double[] rectangleArray = new double[2];
            Console.WriteLine("\n Inserire lato 1:\n");
            rectangleArray[0] = double.Parse(Console.ReadLine());
            Console.WriteLine("\n Inserire lato 2:\n");
            rectangleArray[1] = double.Parse(Console.ReadLine());


            return rectangleArray;
        }

        private static double GetCircleData()
        {
            double radius;
            Console.WriteLine("\n Inserire raggio:\n");
            radius = double.Parse(Console.ReadLine());

            return radius;
        }

        private static double GetSquareData()
        {
            double lato;
            Console.WriteLine("\n Inserire lato:\n");
            lato = double.Parse(Console.ReadLine());

            return lato;

        }

        private static double[] GetTriangleData()
        {

            double[] triangleArray = new double[4];
            Console.WriteLine("\n Inserire lato 1:\n");
            triangleArray[0] = double.Parse(Console.ReadLine());
            Console.WriteLine("\n Inserire lato 2:\n");
            triangleArray[1] = double.Parse(Console.ReadLine());
            Console.WriteLine("\n Inserire lato 3:\n");
            triangleArray[2] = double.Parse(Console.ReadLine());
            Console.WriteLine("\n Inserire altezza:\n");
            triangleArray[3] = double.Parse(Console.ReadLine());

            return triangleArray;

        }
    }
