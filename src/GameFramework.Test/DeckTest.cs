using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GameFramework.Test.Framework;

namespace GameFramework.Test
{
    [TestFixture]
    public class DeckTest : MockingBaseTest
    {
        [Test]
        public void ShouldBeAStronglyTypedCollectionOfICard()
        {
            var deck = new Deck();
            deck.Add(Mock<ICard>());
            deck[0].ShouldBeOfType<ICard>();
        }
    }
}