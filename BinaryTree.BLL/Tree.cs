using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree.BLL
{
    public class Tree
    {
        private int _value;
        private Tree _left, _right, _ancestor;

        /// <summary>
        /// Add the new value to the tree
        /// </summary>
        /// <param name="value"></param>
        public void Add(int value, int ancestor = 0)
        {
            if(_ancestor == null)
            {
                _ancestor = new Tree();
                _ancestor._value = ancestor;
            }

            if (_value == 0)
            {
                _value = value;
            }
            else
            {
                if (value < _value)
                {
                    if (_left == null)
                        _left = new Tree();
                    _left.Add(value,_value);
                }
                else if(value > _value)
                {
                    if (_right == null)
                        _right = new Tree();
                    _right.Add(value,_value);
                }
            }
        }

        /// <summary>
        /// Traverse the Tree to print it.
        /// First the root, then the lef node and finally, the right node.
        /// </summary>
        public void Preorder(ref List<int> Tree)
        {   
            if (_value != 0)
            {   
                Tree.Add(_value);

                if (_left != null)
                    _left.Preorder(ref Tree);
                if (_right != null)
                    _right.Preorder(ref Tree);
            }
        }


        /// <summary>
        /// Validates whether a value exist in the Tree
        /// </summary>
        /// <param name="value">Value to validate whether exist</param>
        /// <returns></returns>
        public bool Exist(int value)
        {
            if(_value != 0)
            {
                if (value == _value)
                {
                    return true;
                }
                else if (_left != null && value < _value)
                {
                    return _left.Exist(value);
                }
                else if (_right != null && value > _value)
                {
                    return _right.Exist(value);
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
            
            ancestors.Add(_ancestor._value);

            if (_left != null && value < _value)
            {
                _left.GetAncestor(value, ref ancestors);
            }
            else if (_right != null && value > _value)
            {
                _right.GetAncestor(value, ref ancestors);
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
