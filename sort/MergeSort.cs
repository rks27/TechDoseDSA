using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TechDoseDSA
{
    public static class MergeSort
    {
        public static int[] Sort(int[] input)
        {
            if (input.Length <= 1)
            {
                return input;
            }


            var mid = input.Length % 2 > 0 ? input.Length / 2 + 1 : input.Length / 2;

            int[] left = new int[mid];
            int[] right = new int[input.Length - mid];

            for (int i = 0; i < input.Length; i++)
            {
                if( i < mid)
                {
                    left[i] = input[i];
                }
                else
                {
                    right[i - mid] = input[i];
                }
            }

            return Merge(Sort(left), Sort(right));
        }


        
        public static int[] Merge(int[] arr1, int[] arr2)
        {
            return MergeSortedArray.Merge(arr1, arr2);
        }

    }
}
