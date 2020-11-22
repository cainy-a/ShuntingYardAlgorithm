using System;
using System.Linq;
using System.Text;

namespace ShuntingYardAlgorithm.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an infix-notation equation: ");
            var infix = Console.ReadLine();
            var yard = new ShuntingYard(infix);
            if (!yard.ShuntValid)
            {
                Console.WriteLine("Input equation is empty");
                return;
            }
            yard.Shunt();
            var sb = new StringBuilder();
            sb.AppendJoin(' ', yard.Output.Select(s => s.ToString()).ToArray());
            var rpn = sb.ToString();
            Console.WriteLine("Your Reverse Polish Notation / Postfix Notation equation is:\n" + rpn);
        }
    }
}
