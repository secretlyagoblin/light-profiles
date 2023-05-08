using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightProfiles.Tests
{

    public class ProfilePointTests
    {
        [Test]
        public void DoesThrowSmall()
        {
            try
            {
                new ProfilePoint(-0.000001f, 12);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void DoesThrowLarge()
        {
            try
            {
                new ProfilePoint(1.000001f, 12);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void DoesConstruct()
        {
                var p = new ProfilePoint(0.000001f, 12);

            Assert.IsNotNull(p);
            Assert.AreEqual(0.000001f, p.PercentageX);
            Assert.AreEqual(12, p.AbsoluteY);
        }
    }
}
