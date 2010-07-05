using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GameFramework.Test.Framework
{
    public abstract class BaseTest
    {
        public virtual void BeforeAllTests()
        {
        }

        public virtual void BeforeEachTest()
        {
        }

        public virtual void AfterEachTest()
        {
        }

        public virtual void AfterAllTests()
        {
        }
    }
}
