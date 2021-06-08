using System;
using System.Collections.Generic;
using System.Text;

namespace TechDoseDSA.Graph
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }

        public static Node Create(string al)
        {
            // var input = "[[2,4],[1,3],[2,4],[1,3]]".Replace("[[", "").Replace("]]", "").Split("],[");
            var input = al.Replace("[[", "").Replace("]]", "").Split("],[");

            var l = new List<List<int>>();

            foreach (var item in input)
            {
                List<int> toAdd = new List<int>();
                foreach (var item1 in item.Split(","))
                {
                    toAdd.Add(int.Parse(item1));
                }

                l.Add(toAdd);
            }

            return Create(l);

        }

        public static Node Create(List<List<int>> al)
        {
            Dictionary<int, Node> AlreadyCreated = new Dictionary<int, Node>();
            Node result = null;
            for (int i = 0; i < al.Count ; i++)
            {
                if (AlreadyCreated.ContainsKey(i + 1))
                {
                    result = AlreadyCreated[i + 1];
                }
                else
                {
                    result = new Node(i + 1);
                    AlreadyCreated[i + 1] = result;
                }

                var neighbours = new List<Node>();
                foreach (var item1 in al[i])
                {
                    if (!AlreadyCreated.ContainsKey(item1))
                    {
                        AlreadyCreated[item1] = new Node(item1);                        
                    }

                    neighbours.Add(AlreadyCreated[item1]);
                }

                if (neighbours.Count > 0) result.neighbors = neighbours;
            }
            
            return result;
        }

    }
    public class CloneGraph133
    {
        public Node CloneGraph(Node node)
        {
            var v = new Dictionary<int, Node>();
            return f(node, v);
        }

        private Node f(Node n, Dictionary<int, Node> v)
        {
            Node result = null;
            if (n != null) // not visited
            {
                if (!v.ContainsKey(n.val))
                {
                    result = new Node();                    
                    result.val = n.val;
                    v[n.val] = result;
                    if (n.neighbors != null)
                    {
                        result.neighbors = new List<Node>();

                        foreach (var item in n.neighbors)
                        {
                            result.neighbors.Add(f(item, v));                            
                        }
                    }
                    
                }
                else
                {
                    result = v[n.val];
                }
            }
           
            return result;
        }
    }
}
