# ShuntingYardAlgorithm
[![CodeFactor](https://www.codefactor.io/repository/github/cainy-a/shuntingyardalgorithm/badge)](https://www.codefactor.io/repository/github/cainy-a/shuntingyardalgorithm)

An implementation of [Dijkstra's Shunting-Yard Algorithm](https://en.m.wikipedia.org/wiki/Shunting-yard_algorithm) for converting [Infix Notation](https://en.m.wikipedia.org/wiki/Infix_notation) to [Reverse Polish / Postfix Notation](https://en.m.wikipedia.org/wiki/Reverse_Polish_notation).

## Usage
- Download a dll build, and reference it. (Might do Nuget if I get time)
- Create a `ShuntingYard`, and populate it either with a space-separated string, or with a set of `Symbol`s.
- Check to make sure that `ShuntValid` is true (or just use a try catch I don't care), then run `Shunt()`.
- Finally get `Output`, which is a `Symbol[]` and do as you wish with it.

## Quick example:
```
var yard = new ShuntingYard("31 + 4 / ( 11 - 7 ) + sin ( 32 )");
if (!yard.ShuntValid) return;
yard.Shunt();
foreach (var symbol in yard.Output)
	Console.Write(symbol.ToString() + " ");
	// 31 4 11 7 - / + 32 sin +
```

## Documentation
### `class ShuntingYard`
Shunting-Yard algorithm: convert infix notation to RPN

Constructor:
- `(string equation)`: A string of space-separated operators and operands
- `(IEnumerable<Symbol> equation)`: List or Array of Symbols

Members:
- `Input`, `Symbol[]`, `public`: Input to Shunting-Yard Algorithm.
- `OperatorStack`, `Stack<Operator>`, `public`: Stack of operators, used while Shunt()ing, empty otherwise
- `Output`, `Symbol[]`, `public`: Output from the last Shunt()
- `ShuntValid`, `bool`, `public`: Whether everything is set up ready for Shunt()

Static Methods:
- `ParseEquation()`, `IEnumerable<Symbol>`, `public static`: Parses a string representing an equation into an equivalent IEnumerable.
	Accepted names for functions are: `sin`, `cos`, `tan`, `min`, `max`, and `func`
	The order of operations used is as follows:
	* Functions
	* Powers
	* Multiply / Divide
	* Addition / Subtraction
	* Parentheses (these can theoretically be anywhere of the order of operations as they are handled with a special case)

Methods:
- `Shunt()`, `void`, `public`: Performs the Shunting-Yard Algorithm

### `class Symbol`
Base class which Operator and Operand inherit

Constructor:
- `(string value)`: The value of the symbol

Methods:
- `ToString()`, `string`, `public`: Gets the value of the symbol

### `class Operand : Symbol`
Represents a number in an equation

Constructor:
- `(int value)`: Int represented
- `(float value)`: Float represented

Members:
- `OperandType`, `OperandType`, `public`: Whether the Operand is int or float

Methods:
- `ToInt()`, `int`, `public`: Gets an int representing the Operand
- `ToFloat()`, `int`, `public`: Gets a float representing the Operand

### `enum OperandType`
- Int
- Float

### `class Operator : Symbol`
An operator or function in an equation

Constructor:
- `(string value, Operators op, int precedence, bool isRightAssociative = false)`:
	* `string value`: The value of the operator
	* `Operators op`: What type of operator it is
	* `int precedence`: The precedence of the operator. Higher = sooner in order of operations. Suggested precedences:
		| op   |   |
		|------|---|
		| func | 5 |
		| ^    | 4 |
		| * /  | 3 |
		| + -  | 2 |
		| ( )  | 0 |
	* `bool isRightAssociative` *(optional)*: Whether or not the operator is right associative (notable example: power `^`)

Members:
- `Precedence`, `int`, `public`: The precedence of the operator. Higher means sooner in order of operations
- `IsRightAssociative`, `bool`, `public`: Whether the operator is right associative, i.e. powers (`x^y`)
- `Op`, `Operators`, `public`: What type of operator it is

### `enum Operators`
- Addition
- Subtraction
- Multiplication
- Division
- OpenBracket
- CloseBracket
- Power
- Function
