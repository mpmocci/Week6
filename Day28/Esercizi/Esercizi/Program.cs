using System;

namespace Esercizi
{
    class Program
    {
        static void Main(string[] args)
        {

            ///***NUM PRIMI***/
            //int min, max, dimensioneArray;
            //min = AskNumber("minimo", out min);
            //do
            //{
            //    AskNumber("massimo", out max);
            //}
            //while (max < min);

            //dimensioneArray = max - min + 1;
            //int[] array = new int[dimensioneArray];
            //array = FillArray(min, max);

            //CheckPrimeNumber(ref  array, ref dimensioneArray);


            int[] array = new int[8];
            array = GetArray();

            //5,6,4,8

            for(int i=0; i<7; i++)
            {
                for(int j=i+1; j<8; j++)
                {
                    int a;

                    if(array[i]> array[j])
                    {
                        a = array[i];
                        array[i] = array[j];
                        array[j] = a;
                    }


                }

            }


            for(int k=0; k<8; k++)
            {
                Console.WriteLine($"\n{array[k]}\n");
            }



        }

        private static int[] GetArray()
        {

            int[] array = new int[8];

            for (int i=0; i<8; i++)
            {
                int num;
                do
                {
                    Console.WriteLine("Inserire un num:\n");
                }
                while (!(int.TryParse(Console.ReadLine(), out num)));

                array[i] = num;

            }

            return array;
        }

        private static int[] FillArray(int min, int max)
        {
            int[] array = new int[max - min + 1];


            for (int i=0; i<=max-min; i++)
            {
                array[i] = min + i;
            }

            return array;
        }

        private static void CheckPrimeNumber(ref int[] array, ref int n)
        {


            for(int i=0; i<n; i++)
            {

                bool isPrimo = true;

                for (int j=2; j<array[i]; j++)
                {

                    if (array[i] % j ==0)
                    {
                        isPrimo = false;

                    }


                }


                if (isPrimo == false)
                {
                    Console.WriteLine($"{array[i]} non è un numero primo");
                }
                else
                {
                    Console.WriteLine($"{array[i]}  è un numero primo");
                }



            }




        }

        public static int AskNumber(string valore, out int number)
        {

            do
            {
                Console.WriteLine($"Inserisci il valore {valore}:\n");
            }
            while (!(int.TryParse(Console.ReadLine(), out number)));

            return number;
        }
    }
}
