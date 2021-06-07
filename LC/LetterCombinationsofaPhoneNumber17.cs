using System;
using System.Collections.Generic;
using System.Text;

namespace TechDoseDSA
{
     public class LetterCombinationsofaPhoneNumber17
    {
        string[] m_Map = { "", "", "abc", "def", "ghi" , "jkl", "mno", "pqrs", "tuv", "wxyz" };
        public IList<string> LetterCombinations(string digits)
        {
            return f(digits, digits.Length);           
        }

        private List<string> f(string digits, int n)
        {
            var toReturn = new List<string>();

            if (string.IsNullOrEmpty(digits))
            {
                return toReturn;
            }

            
            if (n == 1)
            {
                string temp = m_Map[int.Parse(digits.Substring(n - 1, 1))];
                foreach (var item in temp)
                {
                    toReturn.Add(item.ToString());
                }
            }
            else
            {
                string temp = m_Map[int.Parse(digits.Substring(n - 1, 1))];
                var tempRes = f(digits, n - 1);
                
                // Permutating for
                foreach (var item in tempRes)
                {
                    foreach (var item1 in temp)
                    {
                        toReturn.Add(item + item1.ToString());
                    }
                }
                
            }

            return toReturn;

        }
    }
}
