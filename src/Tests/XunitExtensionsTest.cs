using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Cloud.Core.Testing.Tests
{
    public class XUnitExtensions
    {
        [Fact, IsUnit]
        public void Test_XUnitExtensions_FailPass()
        {
            Assert.Throws<XunitException>(() => AssertExtensions.Fail());
        }

        [Fact, IsDev]
        public void Test_XUnitExtensions_Fail()
        {
            Assert.Throws<XunitException>(() => AssertExtensions.Fail());
        }

        [Fact, IsIntegration]
        public void Test_XUnitExtensions_DoesNotThrowPass()
        {
            AssertExtensions.DoesNotThrow(() => { }); 
        }

        [Fact, IsIntegrationReadOnly]
        public void Test_XUnitExtensions_DoesNotThrowFail()
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
