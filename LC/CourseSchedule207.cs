using System;
using System.Collections.Generic;
using System.Text;

namespace TechDoseDSA.Graph
{
    public class CourseSchedule207
    {
        public static List<List<int>> CreateALFromEL(int n, int[][] prerequisites)
        {
            var al = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                al.Add(new List<int>());
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                al[prerequisites[i][1]].Add(prerequisites[i][0]);
            }

            return al;
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            
            var visted = new int[numCourses];
            var al = CreateALFromEL(numCourses, prerequisites);

            for (int i = 0; i < numCourses; i++)
            {
                if (!f(i, visted, al))
                {
                    return false;
                }
                
            }

            return true;

            
        }

        private bool f(int i, int[] v, List<List<int>> al)
        {
            if (v[i] != 2) // Course is not marked completed 
            {
                 if (v[i] == 1)
                {
                    // processing again 
                    return false;
                }
                else
                {
                    v[i] = 1;
                }

                for (int j = 0; j < al[i].Count; j++)
                {
                    if (!f(al[i][j], v, al))
                    {
                        return false;
                    }
                }

                v[i] = 2; //completed 
            }

            return true;
        }
    }
}
