using System;
using System.Collections.Generic;
using System.Text;

namespace TechDoseDSA
{
    public class LargestRectangleInHistogram84bruteforce
    {
        public int LargestRectangleArea(int[] heights)
        {
            int largestRect = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                var l = i;
                var r = i;

                while ((l - 1 >= 0 && heights[l - 1] >= heights[i]) || (r + 1 < heights.Length && heights[r + 1] >= heights[i]))
                {
                    if (l - 1 >= 0 && heights[l - 1] >= heights[i]) l--;
                    if (r + 1 < heights.Length && heights[r + 1] >= heights[i]) r++;
                }

                var area = (r - l + 1) * heights[i];
                if (area > largestRect) largestRect = area;
            }

            return largestRect;
        }
    }
}
