using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parentesis = Console.ReadLine().ToCharArray();

            Queue<char> queue = new Queue<char>();

            for (int i = 0; i < parentesis.Length; i++)
            {
                queue.Enqueue(parentesis[i]);
            }

            Queue<char> reversedQueue = new Queue<char>();

            for (int i = parentesis.Length - 1; i >= 0; i--)
            {
                reversedQueue.Enqueue(parentesis[i]);
            }

            if (parentesis.Length % 2 == 0)
            {
                bool isBalanced = true;

                for (int i = 0; i < parentesis.Length / 2; i++)
                {
                    var currentChar = parentesis[i];
                    var firsPart = queue.Dequeue();
                    var secondPart = reversedQueue.Dequeue();

                    if (currentChar == '(')
                    {
                        if (firsPart == '(' && secondPart == ')')
                        {
                            continue;
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }

                    }
                    else if (currentChar == '[')
                    {
                        if (firsPart == '[' && secondPart == ']')
                        {
                            continue;
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    else if (currentChar == '{')
                    {
                        if (firsPart == '{' && secondPart == '}')
                        {
                            continue;
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                }

                if (isBalanced)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
