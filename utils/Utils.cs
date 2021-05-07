using System;

namespace TechDoseDSA
{
    public static class Utils
    {
        public static void Print(int[] input)
        {
            Console.WriteLine("*****");
            for (int i = 0; i < input.Length ; i++)
            {
                Console.WriteLine($"Index : {i}, value {input[i]}");
            }
            Console.WriteLine("^^^^^");
        }

        public static void Print(int[] input, bool horizontal)
        {
            Console.Write("{ ");
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($"{input[i]}, ");
            }

            Console.WriteLine(" } ");

        }
    }
}
