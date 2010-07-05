using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace GameFramework.Test.Framework
{
    public class MockingBaseTest : NUnitBaseTest
    {
        public T Mock<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }
    }
}
