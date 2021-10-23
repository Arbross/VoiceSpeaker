using System;
using Xunit;

namespace TestConverter
{
    public class UnitTestCalculate
    {
        private Server.Calculator Calculator { get; set; } = new Server.Calculator();

        [Fact]
        public void MultiplyTest()
        {
            Assert.Equal(1, Server.Calculator.Multiply(1, 1));
        }

        [Fact]
        public void ShareTest()
        {
            Assert.Equal(1, Server.Calculator.Share(1, 1));
        }

        [Fact]
        public void PlusTest()
        {
            Assert.Equal(3, Server.Calculator.Plus(2, 1));
        }

        [Fact]
        public void MinusTest()
        {
            Assert.Equal(0, Server.Calculator.Minus(1, 1));
        }
    }
}
