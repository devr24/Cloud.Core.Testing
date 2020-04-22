using System;
using System.Linq;
using Xunit;

namespace Cloud.Core.Testing.Tests
{
    [IsUnit]
    public class IntegerExtensionsTest
    {
        /// <summary>Check list of integers are generated in ascending order, as expected using To method.</summary>
        [Fact]
        public void Test_IntegerExtensions_ToPositive()
        {
            // Arrange/Act
            var intArr = 1.To(10).ToList();

            // Assert
            Assert.Equal(10, intArr.Count);
            Assert.Equal(10, intArr[9]);
        }

        /// <summary>Check list of integers are generated in descending order, as expected using To method.</summary>
        [Fact]
        public void Test_IntegerExtensions_ToNegative()
        {
            // Arrange/Act
            var intArr = 10.To(1).ToList();

            // Assert
            Assert.Equal(10, intArr.Count);
            Assert.Equal(1, intArr[9]);
        }
    }
}
