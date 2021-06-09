using System;
using System.Collections.Generic;
using System.Text;

namespace TechDoseDSA.Graph
{
    public class CourseSchedule210
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

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var al = CreateALFromEL(numCourses, prerequisites);
            int[] indegree = CreateIndegreeArray(numCourses, al);
            Queue<int> processQ = new Queue<int>();

            // EnQ all indegree 0 to kick start processing
            // Pick all the vertices with in-degree as 0 and add them into a queue (Enqueue operation)
            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                {
                    processQ.Enqueue(i);
                }
            }
            

            int visitedCount = 0;
            var results = new List<int>();

            // Repeat until the queue is empty.
            while (processQ.Count > 0)
            {
                    // Remove a vertex from the queue(Dequeue operation) and then.
                    int x = processQ.Dequeue();
                
                    results.Add(x);
                    
                    //Increment count of visited nodes by 1.
                    visitedCount++;

                    // Decrease in-degree by 1 for all its neighboring nodes.
                    // x => Node in porcess, al[x] is list => adjecent of x
                    for (int i = 0; i < al[x].Count ; i++)
                    {
                        
                        indegree[al[x][i]] = indegree[al[x][i]] - 1;                        
                        if (indegree[al[x][i]] == 0)
                        {
                            processQ.Enqueue(al[x][i]);
                        }
                    }
            }

            if (visitedCount != numCourses)
            {
                results.Clear();
            }
            
            return results.ToArray();
        }



        // Create Indegree Array
        public static int[] CreateIndegreeArray(int n, List<List<int>> input)
        {
            int[] results = new int[input.Count];
            for (int i = 0; i < n; i++)
            {
                var adjs = input[i];
                foreach (var item in adjs)
                {
                    results[item] = results[item] + 1; // Increase indree
                }
            }

            return results;
        }


        
    }
}
