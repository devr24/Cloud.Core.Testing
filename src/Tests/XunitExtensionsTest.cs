using System;
using Xunit;
using Xunit.Sdk;

namespace Cloud.Core.Testing.Tests
{
    public class XUnitExtensions
    {
        [Fact, IsUnit]
        public void Test_XUnitExtensions_FailPass_Unit()
        {
            Assert.Throws<XunitException>(() => AssertExtensions.Fail());
        }

        [Fact, IsDev]
        public void Test_XUnitExtensions_Fail_Dev()
        {
            Assert.Throws<XunitException>(() => AssertExtensions.Fail());
        }

        [Fact, IsIntegration]
        public void Test_XUnitExtensions_DoesNotThrowPass_Integration()
        {
            AssertExtensions.DoesNotThrow(() => { }); 
        }

        [Fact, IsPerformance]
        public void Test_XUnitExtensions_FailPass_Performance()
        {
            Assert.Throws<XunitException>(() => AssertExtensions.Fail());
        }

        [Fact, IsSmoke]
        public void Test_XUnitExtensions_FailPass_SmokeTest()
        {
            Assert.Throws<XunitException>(() => AssertExtensions.Fail());
        }

        [Fact, IsIntegrationReadOnly]
        public void Test_XUnitExtensions_DoesNotThrowFail_IntegrationReadOnly()
        {
            try
            {

                AssertExtensions.DoesNotThrow(() => throw new Exception());
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }
}
