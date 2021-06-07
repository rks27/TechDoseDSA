using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace TechDoseDSA
{

 // Definition for a binary tree node.
  public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
       }

        public static TreeNode Create(int[] input)
        {
            if (input.Length == 1)
            {
                return new TreeNode(input[0]);
            }
            else if (input.Length == 2)
            {
                return new TreeNode(input[0], new TreeNode(input[1]));
            }
            else if (input.Length == 3)
            {
                return new TreeNode(input[0], new TreeNode(input[1]), new TreeNode(input[2]));
            }
            else
            {
                TreeNode[] arr = new TreeNode[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] != int.MinValue)
                    {
                        arr[i] = new TreeNode(input[i]);
                    }
                }

                for (int i = 0; i < input.Length - 2; i++)
                {
                    if (arr[i] != null)
                    {
                        arr[i].left = arr[2*i + 1];
                        arr[i].right = arr[2*i + 2];
                    }
                }

                return arr[0];
            }
        }

        public static TreeNode Create(int[] input, TreeNode node, int index)
        {
            if (index < input.Length)
            {
                if (input[index] != int.MinValue)
                {
                    node = new TreeNode(input[index]);
                    node.left = Create(input, node.left, 2 * index + 1);
                    node.right = Create(input, node.right, 2 * index + 2);
                }
            }

            return node;
        }
  }


    public class ValidateBinarySearchTree
    {
        private bool f(TreeNode root, long lowerBound, long upperBound)
        {
            if (root == null)
            {
                return true;
            }

            if (root.val <= lowerBound || root.val >= upperBound)
            {
                return false;
            }

            if (root.left != null && (root.left.val >= root.val))
            {
                return false;
            }
            

            if (root.right != null && (root.right.val <= root.val))
            {
                return false;
            }

            
            return f(root.left, lowerBound, Math.Min(upperBound, root.val)) && f(root.right, Math.Max(lowerBound, root.val), upperBound);
        }

        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return f(root, long.MinValue, long.MaxValue);            
        }

    }
}
