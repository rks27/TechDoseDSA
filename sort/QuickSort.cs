using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TechDoseDSA.sort
{
    public static class QuickSort
    {

        static char[] arrPointer;
        public static int[] Sort(int[] input)
        {
            arrPointer = new char[input.Length];
            DoQuickSort(input, 0, input.Length - 1);
            return input;
        }

        private static void DoQuickSort(int[] arr, int from, int to)
        {
            for (int i = 0; i < arrPointer.Length; i++)
            {
                arrPointer[i] = ' ';
            }
            
            if (from >= to)
            {
                return;
            }
            
            // arrPointer[from] = '^';
            arrPointer[to] = '^';
            int pivotValue = arr[to];
            Utils.Print(arr);
            Utils.Print(arrPointer);


            int nextPivotIndex = from;
            for (int i = from; i < to; i++)
            {
                if ( arr[i] < pivotValue)
                {
                    Swap(arr, nextPivotIndex, i);
                    nextPivotIndex++;                    
                }
            }
            
            
            Swap(arr, nextPivotIndex, to);
            
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
