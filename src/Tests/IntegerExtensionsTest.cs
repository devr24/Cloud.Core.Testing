using System;
using System.Linq;
using Xunit;

namespace Cloud.Core.Testing.Tests
{
    [IsUnit]
    public class IntegerExtensionsTest
    {
        [Fact]
        public void Test_IntegerExtensions_ToPositive()
        {
            var intArr = 1.To(10).ToList();

            Assert.Equal(10, intArr.Count);
            Assert.Equal(10, intArr[9]);
        }

        [Fact]
        public void Test_IntegerExtensions_ToNegative()
        {
            var intArr = 10.To(1).ToList();

            Assert.Equal(10, intArr.Count);
            Assert.Equal(1, intArr[9]);
        }
    }
}
