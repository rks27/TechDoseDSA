using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using TechDoseDSA.Graph;
using TechDoseDSA.LC;

namespace TechDoseDSA
{
    static class Program
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

            //var toReturn = PickK(input1, 3);
            //foreach (var item in toReturn)
            //{
            //    foreach (var item1 in item)
            //    {
            //        Console.Write($"{item1},");
            //    }

            //    Console.WriteLine($"");

            //}

            //LetterCombinationsofaPhoneNumber17 obj = new LetterCombinationsofaPhoneNumber17();
            //var res = obj.LetterCombinations("23");

            //int[] input = { 5, 4, 6, int.MinValue, int.MinValue, 3, 7 };
            //ValidateBinarySearchTreeV2 ts = new ValidateBinarySearchTreeV2();
            //// var t = TreeNode.Create(input);


            //int[] input = { 1, 3, int.MinValue, int.MinValue, 2};
            //var t = TreeNode.Create(input, null, 0);
            ////ts.IsValidBST(t1);

            //RecoverBinarySearchTree t1 = new RecoverBinarySearchTree();
            //t1.RecoverTree(t);

            
            var x = TechDoseDSA.Graph.Node.Create("[[2,4],[1,3],[2,4],[1,3]]");
            Console.WriteLine(x);

            CloneGraph133 obj = new CloneGraph133();
            var y = obj.CloneGraph(x);

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

     
        private static List<int[]> PickK(int[] input, int k)
        {
            var toReturn = new List<int[]>();
            if (k == 1)
            {
                for (int l = 0; l < input.Length; l++)
                {
                    toReturn.Add(new int[] { input[l] });
                }
            }
            else if (input.Length == k)
            {
                toReturn.Add(input);             
            }
            else
            {
                    var item = input[0];
                    var newInput = input.RemoveAt(0);

                    // exclude 0
                    var res1 = PickK(newInput, k);

                    // include 0
                    var res2 = PickK(newInput, k - 1);

                    // need to add included item to result
                    foreach (var item1 in res2)
                    {
                        var toAdd = new int[k];
                        Array.Copy(item1, toAdd, item1.Length);

                        toAdd[k - 1] = item;
                        toReturn.Add(toAdd);
                    }

                    // Appending excluded item 
                    toReturn = toReturn.Concat(res1).ToList();
                
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
            

            
            for (int j = 0; j < input.Length; j++)
            {
                results.Add(input[index]);

                var res = PickKRec(input, k, index + 1, results);
                foreach (var item in res)
                {
                    toReturn.Add(item);
                }
            }

            

            
            return toReturn;
        }

        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }
    }
}
