using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ShuntingYardAlgorithm.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ParseTest()
        {
            var yard = new ShuntingYard("3 + 4 / 6 ( 12 * 75 ) - 3");

            IEnumerable<string> expected = new[] { "3", "+", "4", "/", "6", "(", "12", "*", "75", ")", "-", "3" };
            var actual = yard.Input.Select(s => s.ToString());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BasicShuntTest()
        {
            var yard = new ShuntingYard(new Symbol[]
                {new Operand(3), new Operator("+", Operators.Addition, 2), new Operand(4)});

            Assert.True(yard.ShuntValid);
            yard.Shunt();
            Assert.IsEmpty(yard.OperatorStack);
            var expected = new Symbol[] {new Operand(3), new Operand(4), new Operator("+", Operators.Addition, 2)}
                .Select(s => s.ToString());
            var actual = yard.Output
                .Select(s => s.ToString());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AdvancedShuntTest()
        {
            /* TODO: make this test use this equation: 3 + 4 x 2 / ( 1 - 5 ) ^ 2 ^ 3
               it should return this: 3 4 2 x 1 5 - 2 3 ^ ^ / + */

            var yard = new ShuntingYard(new Symbol[]
                {new Operand(3), new Operator("+", Operators.Addition, 2), new Operand(4)});

            Assert.True(yard.ShuntValid);
            yard.Shunt();
            Assert.IsEmpty(yard.OperatorStack);
            var expected = new Symbol[] {new Operand(3), new Operand(4), new Operator("+", Operators.Addition, 2)}
                .Select(s => s.ToString());
            var actual = yard.Output
                .Select(s => s.ToString());

            Assert.AreEqual(expected, actual);
        }
    }
}