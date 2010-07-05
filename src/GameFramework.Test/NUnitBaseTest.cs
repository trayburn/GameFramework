using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GameFramework.Test
{
    [TestFixture]
    public abstract class NUnitBaseTest : BaseTest
    {
        [TestFixtureSetUp]
        public override void BeforeAllTests()
        {
            base.BeforeAllTests();
        }

        [SetUp]
        public override void BeforeEachTest()
        {
            base.BeforeEachTest();
        }

        [TearDown]
        public override void AfterEachTest()
        {
            base.AfterEachTest();
        }

        [TestFixtureTearDown]
        public override void AfterAllTests()
        {
            base.AfterAllTests();
        }
    }
}
