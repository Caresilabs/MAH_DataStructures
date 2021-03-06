﻿/**

Simon Bothén
DA304A VT 2015

**/

using System;
using System.Text;
using System.Linq;

namespace MAH_DA304_Simon_Bothen_Stack
{
    /// <summary>
    /// This is the second exercise which is a class that checks whenever the input parentheses has a correct match.
    /// </summary>
    class UppgB
    {
        private char[] startBrackets = { '{', '(', '<', '[' };
        private char[] endBrackets = { '}', ')', '>', ']' };

        /// <summary>
        /// Default constructor starts the exercise
        /// </summary>
        public UppgB()
        {
            Console.WriteLine("Starting UppgiftB! ");

            // loop while user want to loop. Write exit to exit the loop
            Console.WriteLine("Enter text to parse:");
            while (true)
            {
                String inputData = Console.ReadLine();
                if (inputData.ToLower() == "exit") break;
               
                Stack<char> myStack = new Stack<char>();

                StringBuilder errors = new StringBuilder();
                foreach (char c in inputData)
                {
                    if (startBrackets.Contains(c))
                    {
                        myStack.Push(c);
                    }
                    else if (endBrackets.Contains(c))
                    {
                        if (myStack.IsEmpty())
                        {
                            errors.AppendLine("\t" + c + " is missing the starttag");
                            continue;
                        }

                        char previousBracket = myStack.Pop();

                        if (!Match(previousBracket, c))
                        {
                            errors.AppendLine("\t" + previousBracket + " doesn't match with " + c);
                        }
                    }
                }

                // If my stack contains an uneven amount 
                if (myStack.Count != 0)
                {
                    errors.AppendLine("\tBracket is missing");
                }


                // Print errors if there is any
                if (errors.Length != 0)
                {
                    Console.WriteLine("Errors: \n" + errors);
                }

                Console.WriteLine("Text parsed...");

                if (inputData.ToLower() == "clear") Console.Clear();

                Console.WriteLine("Enter text to parse: (exit to exit)");

            }

            Console.WriteLine("Ending UppgiftB!\n");

        }

        /// <summary>
        /// Check whenever two characters match each other. Only works on parentheses!
        /// </summary>
        /// <param name="x">char 1</param>
        /// <param name="y">char 2</param>
        /// <returns>If a  match was found</returns>
        public bool Match(char x, char y)
        {
            if ((x == '(' && y == ')') || (y == '(' && x == ')'))
                return true;
            if ((x == '[' && y == ']') || (y == '[' && x == ']'))
                return true;
            if (x == '{' && y == '}' || (y == '{' && x == '}'))
                return true;
            if (x == '<' && y == '>' || (y == '<' && x == '>'))
                return true;

            return false;
        }
    }
}

