using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace TechDoseDSA.LC
{
    public class RecoverBinarySearchTree
    {

        TreeNode firstSwapValue, lastSwapValue, previous;
        public void RecoverTree(TreeNode root)
        {
            f(root);
            var temp = lastSwapValue.val;
            lastSwapValue.val = firstSwapValue.val;
            firstSwapValue.val = temp;

        }

        private void f(TreeNode root)
        {
            if (root == null) return;

            f(root.left);

            if (previous != null)
            {
                if (previous.val > root.val)
                {
                    if (firstSwapValue == null)
                    {
                        firstSwapValue = previous;
                    }
                   
                    lastSwapValue = root;
                    
                }
            }

            previous = root;
            f(root.right);
        }

      

    }
}

