using System;
using TechDoseDSA.sort;

namespace TechDoseDSA
{
    class Program
    {
        static void Main(string[] args)
        {
            BobbleSortTest();
        }

        private static void BobbleSortTest()
        {
            Console.WriteLine("Bubble Sort Test");
            var input = new int[] { 2, 3, 1, 6, 4, 5 };
            Utils.Print(input, true);
            Utils.Print(BubbleSort.Sort(input), true);
        }
    }
}
