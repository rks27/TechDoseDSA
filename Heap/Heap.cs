using System;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace TechDoseDSA
{
    public abstract class Heap
    {
        int lastPosition = -1;
        Node[] ArrayNodes = new Node[100];
        protected abstract bool IsMax { get; }

        
        public void Add(Node node)
        {
            
            ArrayNodes[++lastPosition] = node;
            TrickelUp(lastPosition);            
        }
        public void TrickelUp(int position)
        {
            if (position == 0)
            {
                return;
            }


            var parent = (int) Math.Floor((double)(position - 1) / 2);

            if ((IsMax) && (ArrayNodes[parent].Value < ArrayNodes[position].Value))
            {
                Swap(parent, position);
                TrickelUp(parent);                
            }
        }

        private void Swap(int from, int to)
        {
            var temp = ArrayNodes[from];
            ArrayNodes[from] = ArrayNodes[to];
            ArrayNodes[to] = temp;
        }

        public void Print()
        {
            PrintTree(0, "");
        }

        private void PrintTree(int index, String indent)
        {
            if (index > lastPosition)
            {
                return;
            }

            var currNode = this.ArrayNodes[index];
            Console.WriteLine(indent + "+- " + currNode.Value);
            indent += index == lastPosition ? "   " : "|  ";

            var firstChildIndex = 2 * index + 1;
            var secondChildIndex = 2 * index + 2;
            
            PrintTree(firstChildIndex, indent);
            PrintTree(secondChildIndex, indent);

            
        }

    }
}
