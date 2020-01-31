using System;

namespace NWW
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intA = new int[0];
            int[] intB = new int[0];

            int a = InputInteger("Input the first positive integer: ");
            int b = InputInteger("Input the second positive integer: ");
            Console.WriteLine("The following pair combination will be calculated: " + a + ", " + b);
            
            if(a == b)
            {
                Console.WriteLine("NNW calculation result is: " + a);
            }
            else if(a == 1)
            {
                Console.WriteLine("NNW calculation result is: " + b);
            }
            else
            {
                CalculateMultipliersArray(intA, a);
                CalculateMultipliersArray(intB, b);
                DisplayArraysAsColumns(intA, intB);
            }
        }

        private static void DisplayArraysAsColumns(int[] arA, int[] arB)
        {
            Console.WriteLine("Arrays content:");
            Console.WriteLine("A:" + arA.Length + ", B:" + arB.Length);
            for (int i = 0; i < Math.Max(arA.Length, arB.Length) - 1; i++)
            {
                var colA = " ";
                var colB = " ";
                if(i < arA.Length)
                {
                    colA = arA[i].ToString();
                }
                if(i < arB.Length)
                {
                    colB = arB[i].ToString();
                }
                Console.WriteLine(colA + ", " + colB);
                Console.WriteLine(" ");
            }
        }
        private static void CalculateMultipliersArray(int[] intArray, int intNumber)
        {
            for(int i = 2; i <= intNumber; i++)
            {
                float quotient = intNumber / i;
                if((float)quotient - (Int32)quotient == 0 && (float)quotient != 1) //quotient is integer, not 1, 'i' is good to take as multiplier
                {
                    Array.Resize(ref intArray, intArray.Length + 1);   
                    intArray[intArray.Length - 1] = i;
                    CalculateMultipliersArray(intArray, (Int32)quotient);
                }
            }
            //Array.Sort(array: intArray);
        }

        private static int InputInteger(string message)
        {
            Console.WriteLine(message);
            string inputString = Console.ReadLine();
            try
            {
                int inputValue = Convert.ToInt32(inputString);
                if (inputValue < 1 || inputValue > 100)
                {
                    Console.WriteLine("Wrong input " + inputString + ". Default value 1 will be used.");
                }
                else
                {
                    return inputValue;
                }
            }
            catch
            {
                Console.WriteLine("Wrong input " + inputString + ". Default value 1 will be used.");
            } 
            return 1; //return default value when failed to get the valid integer
        }
    }
}
