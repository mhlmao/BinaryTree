using System;

namespace BinaryTree.BLL
{
    public class Tree
    {
        private int _value;
        private Tree _left, _right;

        /// <summary>
        /// Add the new value to the tree
        /// </summary>
        /// <param name="value"></param>
        public void Add(int value)
        {
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
                    _left.Add(value);
                }
                else if(value > _value)
                {
                    if (_right == null)
                        _right = new Tree();
                    _right.Add(value);
                }
                else
                {
                    //TODO: When equals
                }
            }
        }

        /// <summary>
        /// Traverse the Tree to print it.
        /// First the root, then the lef node and finally, the right node.
        /// </summary>
        public void Preorder()
        {   
            if (_value != 0)
            {   
                Console.Write("{0} ",_value);
                if (_left != null)
                    _left.Preorder();
                if (_right != null)
                    _right.Preorder();
            }
        }
    }
}
