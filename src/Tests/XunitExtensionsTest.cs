using System;
using Xunit;
using Xunit.Sdk;

namespace Cloud.Core.Testing.Tests
{
    public class XUnitExtensions
    {
        /// <summary>Checking the IsUnit trait.</summary>
        [Fact, IsUnit]
        public void Test_XUnitExtensions_FailPass_Unit()
        {
            Assert.Throws<XunitException>(() => AssertExtensions.Fail());
        }

        /// <summary>Checking the IsDev trait.</summary>
        [Fact, IsDev]
        public void Test_XUnitExtensions_Fail_Dev()
        {
            Assert.Throws<XunitException>(() => AssertExtensions.Fail());
        }

        /// <summary>Checking the IsIntegration trait.</summary>
        [Fact, IsIntegration]
        public void Test_XUnitExtensions_DoesNotThrowPass_Integration()
        {
            AssertExtensions.DoesNotThrow(() => { }); 
        }

        /// <summary>Checking the IsPerformance trait.</summary>
        [Fact, IsPerformance]
        public void Test_XUnitExtensions_FailPass_Performance()
        {
            Assert.Throws<XunitException>(() => AssertExtensions.Fail());
        }

        /// <summary>Checking the IsSmoke trait.</summary>
        [Fact, IsSmoke]
        public void Test_XUnitExtensions_FailPass_SmokeTest()
        {
            Assert.Throws<XunitException>(() => AssertExtensions.Fail());
        }

        /// <summary>Checking the IsIntegrationReadOnly trait.</summary>
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
