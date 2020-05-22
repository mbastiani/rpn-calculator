using System.Collections.Generic;
using System;

namespace RPNCalculator
{
    public static class Program
    {
        public static void Main()
        {
            try
            {
                var result = Calc("15 7 1 1 + - / 3 * 2 1 1 + + -"); // Result = 5;
                Console.WriteLine(result);
Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static decimal Calc(string args)
        {
            var data = args.Split(' ');
            var stack = new Stack<decimal>();

            foreach (var item in data)
            {
                if (decimal.TryParse(item, out decimal outValue))
                {
                    stack.Push(outValue);
                }
                else
                {
                    switch (item)
                    {
                        case "+":
                            stack.Push(stack.Pop() + stack.Pop());
                            break;
                        case "-":
                            stack.Push(stack.Pop() - stack.Pop());
                            break;
                        case "*":
                            stack.Push(stack.Pop() * stack.Pop());
                            break;
                        case "/":
                            stack.Push(stack.Pop() / stack.Pop());
                            break;
                        default:
                            throw new Exception($"Unknown operator: {item}");
                    }
                }
            }

            return Math.Round(stack.Pop());
        }
    }
}
