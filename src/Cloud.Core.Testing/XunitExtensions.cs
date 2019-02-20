namespace Cloud.Core.Testing
{
    using System.Diagnostics;
    using Xunit;
    using System;

    public static class AssertExtensions
    {
        public static void Fail()
        {
            throw new Xunit.Sdk.XunitException();
        }

        public static void DoesNotThrow(Action performTest)
        {
            try
            {
                performTest();
                Assert.True(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed \"DoesNotThrow\" test with exception {e.Message}");
                Console.WriteLine($"Failed \"DoesNotThrow\" test with exception {e.Message}");
                Assert.True(false);
            }
        }
    }
}
