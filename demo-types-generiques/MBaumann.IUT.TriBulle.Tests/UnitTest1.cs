using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MBaumann.IUT.TriBulle.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] input = new int[] { 3, 2, 1 };
            int[] expected = new int[] { 1, 2, 3 };

            int[] result = Algos.TriBulle.Run(input)
                    .ToArray();

            Assert.Equal(expected[0], result[0]);
            Assert.Equal(expected[1], result[1]);
            Assert.Equal(expected[2], result[2]);
        }

        [Fact]
        public void Test2()
        {
            List<string> input = new List<string>
            {
                "salut", "bonjour", "hello"
            };
            List<string> expected = new List<string>
            {
                "bonjour", "hello", "salut"
            };
            List<string> result = Algos.TriBulle.Run(input)
                .ToList();

            Assert.Equal(expected[0], result[0]);
            Assert.Equal(expected[1], result[1]);
            Assert.Equal(expected[2], result[2]);
        }
    }
}