using System;

namespace TechDoseDSA
{
    public static class Utils
    {
        private static ConsoleColor[] HeightColorArray = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen };

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
                var orig = Console.ForegroundColor;
                var arrow = "";
                if (from == i || to == i)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    arrow = ("\u2194");                    
                }
    
                Console.Write($"[{arr[i]}{arrow}]");
                Console.ForegroundColor = orig;
            }
            
            Console.Write(Environment.NewLine);
        }

        public static void PrintPivot(int[] arr, int to)
        {

            // Console.WriteLine($"Pivot index : {to} , value : {arr[to]}");
            for (int i = 0; i < arr.Length; i++)
            {
                var orig = Console.ForegroundColor;
                var arrow = "";
                if (to == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    arrow = ("\u2191");

                }

                Console.Write($"[{arr[i]}{arrow}]");
                Console.ForegroundColor = orig;
            }
            
            Console.Write(Environment.NewLine);
        }

        public static void PrintCompare(int[] arr, int from, int to)
        {
            if (from > to)
            {
                var tmp = from;
                from = to;
                to = tmp;
            }


            // Console.WriteLine($"Compare index : {from} : {to}");

            for (int i = 0; i < arr.Length; i++)
            {
                var orig = Console.ForegroundColor;
                var arrow = "";
                if (to == i || from == i)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    arrow = ("=");
                }

                Console.Write($"[{arr[i]}{arrow}]");
                Console.ForegroundColor = orig;


            }
            
            Console.Write(Environment.NewLine);           
        }

        public static void PrintTree(Node[] ArrayNodes)
        {
            PrintTree(ArrayNodes, 0, "", 0);

        }

        private static void PrintTree(Node[] ArrayNodes, int index, String indent, int height)
        {
            if (index > ArrayNodes.Length || ArrayNodes[index] == null)
            {
                return;
            }

            var currNode = ArrayNodes[index];
            var orig = Console.ForegroundColor;
            Console.ForegroundColor = HeightColorArray[height];
            Console.WriteLine(indent + "+- " + currNode.Value + $"(Height ={height})");
            Console.ForegroundColor = orig;
            indent += index == ArrayNodes.Length ? "   " : "|  ";
            
            var firstChildIndex = 2 * index + 1;
            var secondChildIndex = 2 * index + 2;

            height++;
            PrintTree(ArrayNodes, firstChildIndex, indent, height);
            PrintTree(ArrayNodes, secondChildIndex, indent, height);


        }
    }
}
