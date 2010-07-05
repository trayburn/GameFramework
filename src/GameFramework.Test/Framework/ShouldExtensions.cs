using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GameFramework.Test.Framework;

namespace GameFramework.Test.Framework
{
    public static class ShouldExtensions
    {
        public static void ShouldBeOfType<T>(this object self)
        {
            Assert.IsInstanceOf<T>(self);
        }
    }
}
