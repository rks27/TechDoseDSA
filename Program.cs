using System;
using System.Collections.Generic;

namespace TechDoseDSA
{
    class Program
    {
        static int[] input1 = new int[] { 10, 3, 1, 6, 4, 5 };
        static int[] input2 = new int[] { 10, 20, 11 };

        static int[] arr = new int[6] { 1, 3, 3, -2, 4, 5 };
        static int[] st = new int[25]; // 4 * n +1 

        static int st_idx = 1;
        static int start = 0, end = 5;

        static void BuildSegTree(int st_i, int[] array, int s, int e)
        {
            if (s > e)
            {
                return;
            }

            if (s == e) // leaf node
            {
                st[st_i] = array[s];
                return;
            }

            // Internal node case 
            int middle = s + (e - s) / 2;
            BuildSegTree(2 * st_i, arr, s, middle);
            BuildSegTree(2 * st_i + 1, arr, middle + 1, e);
            st[st_i] = st[2 * st_i] + st[2 * st_i + 1];
        }


        static void Main(string[] args)
        {
            var x = PickK(input1, 3);

            Console.WriteLine(x);
            
            //LargestRectangleInHistogram84V2 obj = new LargestRectangleInHistogram84V2();
            //obj.LargestRectangleArea(new int[] { 2, 1, 2 });

            //AlienDictionary953 obj = new AlienDictionary953();
            //obj.IsAlienSorted(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz");

            //BuildSegTree(st_idx, arr, start, end);
            //Utils.Print(st);
            //Utils.PrintTree(st, true);
            // BobbleSortTest();
            // Utils.Print(MergeSortedArray.Merge(BubbleSort.Sort(input1), BubbleSort.Sort(input2)), true);
            // Utils.Print(MergeSort.Sort(input2), true);
            // Utils.Print(InsertionSort.Sort(input1), true);
            // Utils.Print(QuickSort.Sort(input1));
            // HeapTest(new MinHeap());
            // HeapTest(new MaxHeap());




            // Build st pre-process







        }

        private static void HeapTest(Heap heap)
        {
            heap.Add(new Node() { Value = 10 });
            heap.Add(new Node() { Value = 15 });
            heap.Add(new Node() { Value = 12 });
            heap.Add(new Node() { Value = 25 });
            heap.Add(new Node() { Value = 25 });
            heap.Add(new Node() { Value = 25 });
            heap.Print();
        }

        private static void BobbleSortTest()
        {
            Console.WriteLine("Bubble Sort Test");
            Utils.Print(input1);
            Utils.Print(BubbleSort.Sort(input1));
        }


        private static List<HashSet<int>> PickK(int[] input, int k)
        {
            var toReturn = new List<HashSet<int>>();
            for (int i = 0; i < input.Length; i++)
            {
                var res = PickKRec(input, k, i, new HashSet<int>());
                foreach (var item in res)
                {
                    toReturn.Add(item);
                }
            }

            return toReturn;
           
        }

        private static List<HashSet<int>> PickKRec(int[] input, int k, int index, HashSet<int> results)
        {
            var toReturn = new List<HashSet<int>>();

            if (results.Count == k)
            {
                toReturn.Add(results);
                results = new HashSet<int>();
            }
            

            if(index < input.Length)
            {
                results.Add(input[index]);
                var res = PickKRec(input, k, index + 1 , results);
                foreach (var item in res)
                {
                    toReturn.Add(item);
                }
                
            }

            return toReturn;
        }
    }
}
