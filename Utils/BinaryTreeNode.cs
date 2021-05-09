using System;
using System.Collections.Generic;
using System.Text;

namespace TechDoseDSA
{
    public class BinaryTreeNode : TreeNode
    {
        public BinaryTreeNode()
        {
            this.Childrens = new Node[2];
        }

        public Node Left
        {
            get 
            {
                return this.Childrens[0];
            }
            set
            {
                this.Childrens[0] = value;
            }
        }

        public Node Right
        {
            get
            {
                return this.Childrens[1];
            }
            set
            {
                this.Childrens[1] = value;
            }
        }
    }
}
