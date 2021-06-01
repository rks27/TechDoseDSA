using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Xml.Serialization;

namespace TechDoseDSA
{

    /**
 In an alien language, surprisingly they also use english lowercase letters, but possibly in a different order. The order of the alphabet is some permutation of lowercase letters.

Given a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the given words are sorted lexicographicaly in this alien language.

 

Example 1:

Input: words = ["hello","leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
Output: true
Explanation: As 'h' comes before 'l' in this language, then the sequence is sorted.
Example 2:

Input: words = ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz"
Output: false
Explanation: As 'd' comes after 'l' in this language, then words[0] > words[1], hence the sequence is unsorted.
Example 3:

Input: words = ["apple","app"], order = "abcdefghijklmnopqrstuvwxyz"
Output: false
Explanation: The first three characters "app" match, and the second string is shorter (in size.) According to lexicographical rules "apple" > "app", because 'l' > '∅', where '∅' is defined as the blank character which is less than any other character (More info).
     */
   
    public class AlienDictionary953
    {

        public bool IsAlienSorted(string[] words, string order)
        {
            Dictionary<char, short> dict = new Dictionary<char, short>();

            // setting the order
            for (short i = 0; i < order.Length; i++)
            {
                dict[order[i]] = i;
            }


            for (short i = 0; i < words.Length; i++)
            {
                for (short j = (short)(i + 1); j < words.Length; j++)
                {
                    string first = words[i];
                    string second = words[j];

                    var end = first.Length <= second.Length ? first.Length : second.Length;


                    bool checkLenghth = false;

                    for (int k = 0; k < end; k++)
                    {
                        if (dict[first[k]] < dict[second[k]]) // no neeed to check next char
                        {
                            break;
                        }
                        else if(dict[first[k]] > dict[second[k]])
                        {
                            return false;
                        }

                        else // (first[k] == second[k])
                        {
                            checkLenghth = true;
                        }


                    }

                    if (checkLenghth)
                    {
                        if (first.Length > second.Length)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }


        public static void SetOrder(string order) 
        {
            


        }


    }
}
