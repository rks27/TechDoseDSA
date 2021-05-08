using System;
using System.Net;
using System.Runtime.InteropServices;

namespace TechDoseDSA
{
    public static class Utils
    {
        public static void Print(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($"[{input[i]}]");
            }

            Console.Write(Environment.NewLine);
        }

        public static void Print(char[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($" {input[i]} ");
            }

            Console.Write(Environment.NewLine);
        }

        public static void PrintSwap(int[] arr, int from, int to)
        {
            
            if (from > to)
            {
                var tmp = from;
                from = to;
                to = tmp;
            }
            
            Console.WriteLine($"Swap index : {from} , {to}");
          
            for (int i = 0; i < arr.Length; i++)
            {
                //if (i == from || i == to)
                //{
                //    Console.Write($"|");
                //}
                //else if (i > from && i < to)
                //{
                //    Console.Write($"___");
                //}
                //else
                //{
                //    Console.Write($"   ");
                //}

                var orig = Console.ForegroundColor;
                if (from == i || to == i)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\u2191");
                    Console.ForegroundColor = orig;
                }

                    
                Console.Write($"[{arr[i]}]");


            }
            
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);

        }
    }
}
