using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace TechDoseDSA
{

 // Definition for a binary tree node.
 

    public class ValidateBinarySearchTreeV2    {
        private bool f(TreeNode root, ref long min, ref bool flag)        
        {
            if (root != null && flag)
            {
                f(root.left, ref min, ref flag);

                if (root.val <= min)
                {
                    flag = false;                    
                }

                min = root.val;
                f(root.right, ref min, ref flag);
            }

            
            return flag;
         }

        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            var min = long.MinValue;
            var flag = true;
            return f(root, ref min, ref flag);
           }

    }
}
