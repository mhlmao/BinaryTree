using System;
using BinaryTree.Entities;
using BinaryTree.BLL;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BLL.Tree tree;
            //Program starts and request input
            tree = RequestInput();

            //Once the input is validated and added the values to the tree, it is printed
            List<int> preorderTree = new List<int>();
            Console.WriteLine("Tree printed in preorder:");
            tree.Preorder(ref preorderTree);
            foreach (int item in preorderTree)
                Console.Write("{0} ", item);

            //Request two values in the tree
            Console.Write("\n\nType two values in the tree to get its lowest common ancestor...\n" +
                "Value 1: ");
            int value1 = Convert.ToInt16(Console.ReadLine());
            Console.Write("Value 2: ");
            int value2 = Convert.ToInt16(Console.ReadLine());
            try
            {
                var commonAncestor = tree.CommonAncestor(
                    value1,
                    value2);
                ShowCommonAncestor(commonAncestor,value1,value2);
            }
            catch(FormatException e)
            {
                Console.Clear();
                Console.WriteLine("The application thrown the next error...\n\n {0} \n\nplease fix it and try again.", e);
            }

            Console.WriteLine("\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Read the user input
        /// </summary>
        /// <returns>User input</returns>
        public static string ReadInput()
        {
            Console.Write("Please insert the value(s) to add to the tree:" +
                "\n\nExample: 70,84,85,78,80,76,49,54,51,37,40,22 \nInput:");
            return Console.ReadLine();
        }

        /// <summary>
        /// Request user input
        /// </summary>
        public static BLL.Tree RequestInput()
        {
            BLL.Tree tree;
            string input;
            do
            {
                input = ReadInput();
                Console.WriteLine("\n");
            }
            while (!ValidateInput(input, out tree));//out: by ref without initialization
            return tree;
        }

        /// <summary>
        /// Validate the user input
        /// </summary>
        /// <param name="input">User input</param>
        public static bool ValidateInput(string input, out BLL.Tree tree)
        {
            tree = new BLL.Tree();
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

        public static void ShowCommonAncestor(int commonAncestor, int value1, int value2)
        {
            Console.WriteLine("\nThe lowest common ancestor between {0} and {1} is {2}", value1, value2, commonAncestor);
        }
    }
}
