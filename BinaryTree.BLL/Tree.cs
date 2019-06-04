using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree.BLL
{
    public class Tree
    {
        public int Value;
        public Tree Left, Right, Ancestor;

        /// <summary>
        /// Add the new value to the tree
        /// </summary>
        /// <param name="value"></param>
        public void Add(int value, int ancestor = 0)
        {
            if(Ancestor == null)
            {
                Ancestor = new Tree();
                Ancestor.Value = ancestor;
            }

            if (Value == 0)
            {
                Value = value;
            }
            else
            {
                if (value < Value)
                {
                    if (Left == null)
                        Left = new Tree();
                    Left.Add(value,Value);
                }
                else if(value > Value)
                {
                    if (Right == null)
                        Right = new Tree();
                    Right.Add(value,Value);
                }
            }
        }

        /// <summary>
        /// Traverse the Tree to print it.
        /// First the root, then the lef node and finally, the right node.
        /// </summary>
        public void Preorder(ref List<int> Tree)
        {   
            if (Value != 0)
            {   
                Tree.Add(Value);

                if (Left != null)
                    Left.Preorder(ref Tree);
                if (Right != null)
                    Right.Preorder(ref Tree);
            }
        }


        /// <summary>
        /// Validates whether a value exist in the Tree
        /// </summary>
        /// <param name="value">Value to validate whether exist</param>
        /// <returns></returns>
        public bool Exist(int value)
        {
            if(Value != 0)
            {
                if (value == Value)
                {
                    return true;
                }
                else if (Left != null && value < Value)
                {
                    return Left.Exist(value);
                }
                else if (Right != null && value > Value)
                {
                    return Right.Exist(value);
                }
                else
                {
                    return false;
                } 
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets all ancestors of a node
        /// </summary>
        /// <param name="value">value to get its ancestor</param>
        /// <param name="ancestors">List by ref to save the ancestors</param>
        public void GetAncestor(int value, ref List<int> ancestors)
        {
            
            ancestors.Add(Ancestor.Value);

            if (Left != null && value < Value)
            {
                Left.GetAncestor(value, ref ancestors);
            }
            else if (Right != null && value > Value)
            {
                Right.GetAncestor(value, ref ancestors);
            }
        }

        /// <summary>
        /// Gets the lowest common ancestor for two nodes in a tree
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public int CommonAncestor(int node1, int node2)
            {
            List<int> listAncestors1 = new List<int>();
            List<int> listAncestors2 = new List<int>();
            IEnumerable<int> commonList = new List<int>();

            if (Exist(node1) && Exist(node2))
            {
                GetAncestor(node1, ref listAncestors1);
                GetAncestor(node2, ref listAncestors2);
                commonList = listAncestors1.Intersect(listAncestors2);
                return commonList.Last();
            }
            return 0;
        }
    }
}
