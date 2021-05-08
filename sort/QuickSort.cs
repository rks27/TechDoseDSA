using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TechDoseDSA.sort
{
    public static class QuickSort
    {

        public static int[] Sort(int[] input)
        {
            Utils.Print(input);
            DoQuickSort(input, 0, input.Length - 1);
            return input;
        }

        private static void DoQuickSort(int[] arr, int from, int to)
        {
            if (from >= to)
            {
                return;
            }
            
            
            int pivotValue = arr[to];
            Utils.PrintPivot(arr, to);
            
            int nextPivotIndex = from;
            for (int i = from; i < to; i++)
            {
                Utils.PrintCompare(arr, i, to);
                if ( arr[i] < pivotValue)
                {
                    Swap(arr, nextPivotIndex, i);
                    nextPivotIndex++;                    
                }
            }

            Console.WriteLine("*** pivot swap *****");            
            Swap(arr, nextPivotIndex, to);            
            Console.WriteLine("********************");
            // 
            DoQuickSort(arr, from, nextPivotIndex - 1);
            DoQuickSort(arr, nextPivotIndex + 1, to);

        }

        private static void Swap(int[] arr , int from, int to)
        {
            Utils.PrintSwap(arr, from, to);
            var tmp = arr[from];
            arr[from] = arr[to];
            arr[to] = tmp;
            

        }
    }
}
