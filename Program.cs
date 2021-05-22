using System;
namespace TechDoseDSA
{
    class Program
    {
        static int[] input1 = new int[] { 10, 3, 1, 6, 4, 5 };
        static int[] input2 = new int[] { 10, 20, 11};

        static void Main(string[] args)
        {
            BobbleSortTest();
            // Utils.Print(MergeSortedArray.Merge(BubbleSort.Sort(input1), BubbleSort.Sort(input2)), true);
            // Utils.Print(MergeSort.Sort(input2), true);
            // Utils.Print(InsertionSort.Sort(input1), true);
            // Utils.Print(QuickSort.Sort(input1));
            HeapTest(new MinHeap());
            //  HeapTest(new MaxHeap());
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
    }
}
