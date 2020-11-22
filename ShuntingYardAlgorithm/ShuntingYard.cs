using System;
using System.Collections.Generic;
using System.Linq;

namespace ShuntingYardAlgorithm
{
    public class ShuntingYard
    {
        public Symbol[] Input { get; private set; }

        public Stack<Operator> OperatorStack { get; private set; }

        public Symbol[] Output { get; private set; }

        public ShuntingYard(string equation)
        {
            Input = ParseEquation(equation).ToArray();
            OperatorStack = new Stack<Operator>();
        }

        public ShuntingYard(IEnumerable<Symbol> equation)
        {
            Input = equation.ToArray();
            OperatorStack = new Stack<Operator>();
        }

        public bool ShuntValid => Input != null && Input.Length != 0;

        public void Shunt()
        {
            // O(n)

            if (!ShuntValid)
                throw new Exception("Shunt() was called without proper initialisation. Check ShuntValid first!");

            var working = new List<Symbol>();

            foreach (var symbol in Input)
            {
                if (symbol.GetType() == typeof(Operand)) working.Add(symbol); // Add any numbers straight to output
                else if (symbol.ToString() != "(" && symbol.ToString() != ")")
                { // Operators
                    var op = (Operator) symbol;

                    // If function, Push() to stack and continue;
                    if (op.Op == Operators.Function)
                    {
                        OperatorStack.Push(op);
                        continue;
                    }

                    while ((OperatorStack.Count != 0 // Stack not empty!
                            && (OperatorStack.Peek().Precedence >
                                op.Precedence // Top operator has higher precedence than current one
                                || (OperatorStack.Peek().Precedence == op.Precedence && !OperatorStack.Peek().IsRightAssociative))
                           ) // Top op has equal precendence and is left associative
                           && OperatorStack.Peek().Op != Operators.OpenBracket) // Top op is not opening bracket
                        working.Add(OperatorStack.Pop());

                    OperatorStack.Push(op); // Add operator to stack
                }
                else switch (symbol.ToString())
                {
                    case "(": // Opening Bracket
                        OperatorStack.Push((Operator) symbol);
                        break;
                    case ")": // Closing Bracket
                    {
                        while (OperatorStack.Peek().Op != Operators.OpenBracket)
                        {
                            if (OperatorStack.Count == 0) throw new Exception("Ran out of stack while looking for left bracket: input had mismatched brackets.");
                            working.Add(OperatorStack.Pop());
                        }

                        if (OperatorStack.Peek().Op == Operators.OpenBracket) OperatorStack.Pop(); // Discard extra brackets
                        break;
                    }
                }
            }

            working.AddRange(OperatorStack); // Final step: pop out entire stack to output
            OperatorStack.Clear(); // Apparently AddRange() will Peek() instead of Pop() if the stack only has one element, failing to clear it

            Output = working.ToArray();
        }

        public static IEnumerable<Symbol> ParseEquation(string inputEquation)
        {
            var tokens = inputEquation
                .Replace('x', '*') // catch wrong symbols in multiplication
                .Replace('÷', '/') // catch wrong symbols in division
                .Split(' ');

            var working = new List<Symbol>();
            foreach (var token in tokens)
            {
                switch (token)
                {
                    case "+":
                        working.Add(new Operator(token, Operators.Addition, 2));
                        break;
                    case "-":
                        working.Add(new Operator(token, Operators.Subtraction, 2));
                        break;
                    case "*":
                        working.Add(new Operator(token, Operators.Multiplication, 3));
                        break;
                    case "/":
                        working.Add(new Operator(token, Operators.Division, 3));
                        break;
                    case "(":
                        working.Add(new Operator(token, Operators.OpenBracket, 0));
                        break;
                    case ")":
                        working.Add(new Operator(token, Operators.CloseBracket, 0));
                        break;
                    case "^":
                        working.Add(new Operator(token, Operators.Power, 4, true));
                        break;
                    case "max":
                    case "min":
                    case "sin":
                    case "cos":
                    case "tan":
                    case "func":
                        working.Add(new Operator(token, Operators.Function, 5));
                        break;
                    default:
                        var isValidInt = int.TryParse(token, out var parsedInt);
                        var isValidFloat = float.TryParse(token, out var parsedFloat);
                        var TOLERANCE = 0.001;
                        if (isValidInt && Math.Abs((float) parsedInt - parsedFloat) < TOLERANCE)
                        {
                            working.Add(new Operand(parsedInt));
                            break;
                        } // if number has no decimal places

                        if (!isValidFloat) throw new Exception($"Token {token} is not an operator nor a valid float.");
                        working.Add(new Operand(parsedFloat));
                        break;
                }
            }

            return working;
        }
    }
}