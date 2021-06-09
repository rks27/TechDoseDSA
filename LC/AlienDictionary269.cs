using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Xml.Serialization;

namespace TechDoseDSA
{

    /**
 There is a new alien language that uses the English alphabet. However, the order among the letters is unknown to you.

You are given a list of strings words from the alien language's dictionary, where the strings in words are sorted lexicographically by the rules of this new language.

Return a string of the unique letters in the new alien language sorted in lexicographically increasing order by the new language's rules. If there is no solution, return "". If there are multiple solutions, return any of them.

A string s is lexicographically smaller than a string t if at the first letter where they differ, the letter in s comes before the letter in t in the alien language. If the first min(s.length, t.length) letters are the same, then s is smaller if and only if s.length < t.length.

 

Example 1:

Input: words = ["wrt","wrf","er","ett","rftt"]
Output: "wertf"
Example 2:

Input: words = ["z","x"]
Output: "zx"
Example 3:

Input: words = ["z","x","z"]
Output: ""
Explanation: The order is invalid, so return "".
 

Constraints:

1 <= words.length <= 100
1 <= words[i].length <= 100
words[i] consists of only lowercase English letters.
     */

    public class AlienDictionary269
    {
        public string AlienOrder(string[] words)
        {
            string result = "";
            var al = CreateAL(words);
            if (al != null)
            {
                result = ToplogicalSort(al);
            }

            return result;
        }

        Dictionary<char, HashSet<char>> CreateAL(string[] words)
        {
            var result = new Dictionary<char, HashSet<char>>();
            
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                for (int j = 0; j < word.Length; j++)
                {
                    if (!result.ContainsKey(word[j]))
                    {
                        result[word[j]] = new HashSet<char>();
                    }
                }
            }

            return SetAL(result, words);            
        }

        public string ToplogicalSort(Dictionary<char, HashSet<char>> al)
        {
            StringBuilder resultBuilder = new StringBuilder();
            var indegreeSet = CreateIndegreeSet(al);
            var processQ = new Queue<char>();

            // EnQ all Zero indegree
            foreach (var key in indegreeSet.Keys)
            {
                if (indegreeSet[key] == 0)
                {
                    processQ.Enqueue(key);
                }
            }

            int visitedNodes = 0;
            while (processQ.Count > 0)
            {
                var alpha = processQ.Dequeue();
                resultBuilder.Append(alpha);
                visitedNodes++;

                var nextAJ = al[alpha];

                foreach (var key in nextAJ)
                {
                    indegreeSet[key] = indegreeSet[key] - 1;
                    
                    if (indegreeSet[key] == 0)
                    {
                        processQ.Enqueue(key);
                    }
                }

            }

            if (visitedNodes != al.Count)
            {
                // there is cycle
                resultBuilder.Clear();
            }

            return resultBuilder.ToString();
        }

        private Dictionary<char, int> CreateIndegreeSet(Dictionary<char, HashSet<char>> al)
        {
            
            Dictionary<char, int> IndegreeSet = new Dictionary<char, int>();

            foreach (var item in al.Keys)
            {
                IndegreeSet[item] = 0;
            }

            foreach (var item in al.Keys)
            {
                var aj = al[item];

                foreach (var item1 in aj)
                {
                   IndegreeSet[item1] = IndegreeSet[item1] + 1;
                }               

            }

            return IndegreeSet;
            
        }

        private Dictionary<char, HashSet<char>> SetAL(Dictionary<char, HashSet<char>> al, string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    var word1 = words[i];
                    var word2 = words[j];

                    var difIndex = 0;
                    while (difIndex < word1.Length && difIndex < word2.Length && word1[difIndex] == word2[difIndex]) difIndex++;

                    // abc and abce is inconclusive 
                    if ((difIndex < word1.Length) && difIndex < word2.Length) // could be same or could be prefix.. no conclusion
                    {
                        al[word1[difIndex]].Add(word2[difIndex]); // added ordered pair
                    }

                    //invlid order ..
                    if (difIndex >= word2.Length && !word2.Equals(word1))
                    {
                        return null;
                    }
                }
            }

            return al;
        }

        public void Run()
        {
            // Input: words = ["wrt","wrf","er","ett","rftt"]
            // Output: "wertf"


            // ["wrt","wrf","er","ett","rftt"]
            var x = AlienOrder(new string[] { "wrt", "wrf", "er", "ett", "rftt" });

        }
    }
}
