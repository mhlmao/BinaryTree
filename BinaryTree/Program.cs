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
            short value;

            do
            {
                input = RequestValue();
                Console.Clear();
            }
            while (!ValidateInput(input, out value));


            Node node = new Node { Value = value};

            BinaryTreeManager binaryTreeManager = new BinaryTreeManager();
            binaryTreeManager.AddNode(new Node());
        }

        /// <summary>
        /// Solicita y lee el valor ingresado por el usuario
        /// </summary>
        /// <returns></returns>
        public static string RequestValue()
        {
            Console.Write("Por favor ingrese un valor para el nodo: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Valida que el valor ingresado por el usuario sea un número
        /// </summary>
        /// <param name="input">El valor ingresado por el usuario</param>
        public static bool ValidateInput(string input, out short value)
        {
            //Trata de convertir la entrada del usuario en un entero
            if (!short.TryParse(input, out value))
            {
                Console.WriteLine("El valor ingresado debe ser un número...");
                return false;
            }
            return true;
        }
    }
}
