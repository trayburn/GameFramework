using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GameFramework.Test.Framework;
using Rhino.Mocks;

namespace GameFramework.Test
{
    [TestFixture]
    public class DeckTest : MockingBaseTest
    {
        [Test]
        public void ShouldBeAbleToAddCards()
        {
            var deck = new Deck(Mock<IGame>());
            deck.Add(Mock<ICard>());
            deck.Count().ShouldBe(1);
        }

        [Test]
        public void ShouldBeAStronglyTypedCollectionOfICard()
        {
            var deck = new Deck(Mock<IGame>());
            deck.Add(Mock<ICard>());
            deck[0].ShouldBeOfType<ICard>();
        }

        [Test]
        public void ShouldBeAbleToCheckValidity()
        {
            var deck = new Deck(Mock<IGame>());
            deck.Validate().ShouldBeTrue();
        }

        [Test]
        public void ShouldImplementIValidate()
        {
            var deck = new Deck(Mock<IGame>());
            deck.ShouldBeOfType<IValidate>();
        }
    }
}