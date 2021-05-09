using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TechDoseDSA
{
    public static class BubbleSort
    {
        public static int[] Sort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                bool swap = false;
                for (int j = 0 ; j < input.Length - i - 1;  j++)
                {
                    if (input[j] > input[j + 1])
                    {
                        var temp = input[j + 1];
                        input[j + 1] = input[j];
                        input[j] = temp;
                        swap = true;
                    }                    
                }

                if (!swap) break;
            }

            return input;
        }
    }
}
