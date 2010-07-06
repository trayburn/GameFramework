using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GameFramework.Test.Framework;
using Rhino.Mocks;
using System.Collections.Specialized;

namespace GameFramework.Test
{
    [TestFixture]
    public class DeckTest : MockingBaseTest
    {
        private Deck deck;
        private static int HitTest;

        public override void BeforeEachTest()
        {
            base.BeforeEachTest();
            deck = new Deck(Mock<IGame>());
            DeckTest.HitTest = 0;
        }

        [Test]
        public void ShouldBeAbleToAddCards()
        {
            deck.Add(Mock<ICard>());
            deck.Count().ShouldBe(1);
        }

        [Test]
        public void ShouldBeAStronglyTypedCollectionOfICard()
        {
            deck.Add(Mock<ICard>());
            deck[0].ShouldBeOfType<ICard>();
        }

        [Test]
        public void ShouldBeAbleToCheckValidity()
        {
            deck.Validate().ShouldBeTrue();
        }

        [Test]
        public void ShouldImplementIValidate()
        {
            deck.ShouldBeOfType<IValidate>();
        }

        [Test]
        public void ShouldImplementINotifyCollectionChanged()
        {
            deck.ShouldBeOfType<INotifyCollectionChanged>();
        }

        [Test]
        public void ShouldRaiseAnEventWhenCollectionHasChanged()
        {
            deck.CollectionChanged += (s, e) => ++DeckTest.HitTest;

            deck.Add(Mock<ICard>());

            DeckTest.HitTest.ShouldBe(1);
        }

        [Test]
        public void ShouldBeAbleToDrawAHandOfMultipleCards()
        {
            for (int i = 0; i < 10; i++)
            {
                deck.Add(Mock<ICard>());
            }

            deck.Count.ShouldBe(10);

            var hand = deck.Draw(5);

            hand.Count().ShouldBe(5);
            deck.Count.ShouldBe(5);
        }

        [Test]
        public void ShouldBeAbleToDrawAHandOfOneCard()
        {
            for (int i = 0; i < 10; i++)
            {
                deck.Add(Mock<ICard>());
            }

            deck.Count.ShouldBe(10);

            var hand = deck.Draw();

            hand.ShouldBeOfType<ICard>();
            deck.Count.ShouldBe(9);
        }
    }
}