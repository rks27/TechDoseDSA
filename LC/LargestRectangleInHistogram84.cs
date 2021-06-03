using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TechDoseDSA
{
    public class LargestRectangleInHistogram84V2
    {
        public int LargestRectangleArea(int[] heights)
        {
            
            Point[] sappningRactanglesIndices = new Point[heights.Length];

            var maxRightIndex = heights.Length - 1;
            var rightStack = new Stack<int>();
            var leftStack = new Stack<int>();
            // 
            for (int i = 0, j = maxRightIndex; i < heights.Length; i++, j--)
            {
                if (sappningRactanglesIndices[i] == null) sappningRactanglesIndices[i] = new Point();
                if (sappningRactanglesIndices[j] == null) sappningRactanglesIndices[j] = new Point();

                sappningRactanglesIndices[i].X = GetRangeIndex(heights, leftStack, i, 0);
                sappningRactanglesIndices[j].Y = GetRangeIndex(heights, rightStack, j, maxRightIndex);
            }

            int largestRect = 0;
            for(int i=0; i < sappningRactanglesIndices.Length; i++)
            {
                var area = (sappningRactanglesIndices[i].Y - sappningRactanglesIndices[i].X + 1) * heights[i];
                largestRect = Math.Max(area, largestRect);
            }

            Console.WriteLine(largestRect);
            return largestRect;


        }

        
       
        private static int GetRangeIndex(int[] heights, Stack<int> stack, int index, int boundry)
        {
            while (stack.Count > 0 && heights[index] <= heights[stack.Peek()])
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                stack.Push(index);
                return boundry;                
            }
            else
            {
                var temp  = stack.Peek();
                stack.Push(index);
                return temp + (boundry == 0 ? 1 : -1);
            }
        }
    }
}
