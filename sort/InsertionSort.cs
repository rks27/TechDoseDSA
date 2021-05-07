using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TechDoseDSA.sort
{
    public static class InsertionSort
    {
        public static int[] Sort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var currentValue = input[i];
                var j = i - 1;

                for (; j >= 0 && currentValue < input[j] ; j--)
                {
                    input[j + 1] = input[j];
                }

                input[j + 1] = currentValue;

            }

            return input;
        }
    }
}
