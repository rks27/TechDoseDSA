using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace TechDoseDSA
{
    public static class MergeSortedArray
    {
        public static int[] Merge(int[] array1, int[] array2)
        {
            var totalLength = array1.Length + array2.Length;
            int i = 0, j = 0;
            var toReturn = new int[totalLength]; 
            while(i < array1.Length && j < array2.Length)
            {
                if (array1[i] <= array2[j])
                {
                    toReturn[i + j] = array1[i];
                    i++;                    
                }
                else 
                {
                    toReturn[i + j] = array2[j];                    
                    j++;                    
                }
            }

            for (; i < array1.Length; i++)
            {
                toReturn[i + j] = array1[i];
            }

            for (; j < array2.Length; j++)
            {
                toReturn[i + j] = array2[j];
            }

            return toReturn;
        }
    }
}
