using System;
using BinaryTree.Entities;
using BinaryTree.BLL;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Tree tree;

            //Program starts and request input
            do
            {
                input = RequestValue();
                Console.WriteLine("\n");
            }
            while (!ValidateInput(input, out tree));//out: by ref without initialization

            //Once the input is validated and added the values to the tree, it is printed
            Console.WriteLine("Tree printed in preorder:");
            tree.Preorder();
            Console.WriteLine(tree.CommonAncestor(40, 78));
            Console.WriteLine(tree.CommonAncestor(51, 37));
            Console.WriteLine(tree.CommonAncestor(76, 85));
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Request user input
        /// </summary>
        /// <returns>User input</returns>
        public static string RequestValue()
        {
            Console.Write("Please insert the value(s) to add to the tree:" +
                "\n\nExample: 78, 45, 24 \nInput:");
            return Console.ReadLine();
        }

        /// <summary>
        /// Validate the user input
        /// </summary>
        /// <param name="input">User input</param>
        public static bool ValidateInput(string input, out Tree tree)
        {
            tree = new Tree();
            string[] inputSplitted =  input.Split(",");

            foreach (string splitted in inputSplitted)
            {
                //Trata de convertir la entrada del usuario en un entero
                if (!short.TryParse(splitted, out short splitShort))
                {
                    Console.WriteLine("The input isn't in a correct format");
                    return false;
                }
                tree.Add(splitShort);
            }
            return true;
        }
    }
}
