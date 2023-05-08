using NUnit.Framework;
using System.Collections.Generic;

namespace LightProfiles.Tests
{
    public class CoreProfileTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SimpleLineTest()
        {
            var points = new List<ProfilePoint>()
            {
                new ProfilePoint(0,0),
                new ProfilePoint(1,12)
            };
            var profile = new Profile("TestProfile",points);

            Assert.AreEqual(0f, profile.HeightAt(-0.2f));
            Assert.AreEqual(0f, profile.HeightAt(0.0f));
            Assert.AreEqual(3f, profile.HeightAt(0.25f));
            Assert.AreEqual(6f, profile.HeightAt(0.5f));
            Assert.AreEqual(9f, profile.HeightAt(0.75f));
            Assert.AreEqual(12f, profile.HeightAt(1f));
            Assert.AreEqual(12f, profile.HeightAt(1.2f));
        }

        [Test]
        public void SimplePointTest()
        {
            var points = new List<ProfilePoint>()
            {
                new ProfilePoint(0.3f,12),
            };
            var profile = new Profile("TestProfile", points);

            Assert.AreEqual(12f, profile.HeightAt(-0.2f));
            Assert.AreEqual(12f, profile.HeightAt(0.0f));
            Assert.AreEqual(12f, profile.HeightAt(0.25f));
            Assert.AreEqual(12f, profile.HeightAt(0.5f));
            Assert.AreEqual(12f, profile.HeightAt(0.75f));
            Assert.AreEqual(12f, profile.HeightAt(1f));
            Assert.AreEqual(12f, profile.HeightAt(1.2f));
        }

        [Test]
        public void PartialGraphTest()
        {
            var points = new List<ProfilePoint>()
            {
                new ProfilePoint(0f,6),
                new ProfilePoint(0.3f,12),
            };
            var profile = new Profile("TestProfile", points);

            Assert.AreEqual(6f, profile.HeightAt(-0.2f));
            Assert.AreEqual(9f, profile.HeightAt(0.15f));
            Assert.AreEqual(12f, profile.HeightAt(0.3f));
            Assert.AreEqual(12f, profile.HeightAt(0.5f));
            Assert.AreEqual(12f, profile.HeightAt(0.75f));
            Assert.AreEqual(12f, profile.HeightAt(1f));
            Assert.AreEqual(12f, profile.HeightAt(1.2f));
        }
    }
}