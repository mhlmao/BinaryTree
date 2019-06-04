using System;

namespace BinaryTree.Entities
{
    public class Tree
    {
        public int Value { get; set; }
        public Tree Left { get; set; }
        public Tree Right { get; set; }
        public Tree Ancestor { get; set; }
    }
}
