namespace Cloud.Core.Testing
{
    using Xunit;
    using System;

    /// <summary>
    /// Assert extension methods.
    /// </summary>
    public static class AssertExtensions
    {
        /// <summary>
        /// Fails by throwing an Xunit exception.
        /// </summary>
        /// <exception cref="Xunit.Sdk.XunitException"></exception>
        public static void Fail(string message = null)
        {
            throw new Xunit.Sdk.XunitException(message);
        }

        /// <summary>
        /// Assert that the action does not throw an exception.
        /// </summary>
        /// <param name="performTest">The perform test.</param>
        public static void DoesNotThrow(Action performTest)
        {
            try
            {
                // Run test action.
                performTest();

                // If ran without errors, then assert true to pass the testcase.
                Assert.True(true);
            }
            catch (Exception e)
            {
                Assert.True(false, $"Failed \"DoesNotThrow\" test with exception {e.Message}");
            }
        }
    }
}
