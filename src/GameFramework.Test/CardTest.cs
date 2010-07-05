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
    public class CardTest : MockingBaseTest
    {
        private IGame game;
        private Card card;

        public override void BeforeEachTest()
        {
            base.BeforeEachTest();
            game = Mock<IGame>();
            card = new Card(game);
            game.Stub(g => g.Suits).Return(new string[] { "Clubs", "Hearts", "Joker" });
            game.Stub(g => g.Values).Return(new string[] { "1", "2", "3", "4", "5", "Black" });
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldOnlyAllowSuitsFromItsIGame()
        {
            card.Suit = "Spade";
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldOnlyAllowValuesFromItsIGame()
        {
            card.Value = "6";
        }

        [Test]
        public void ShouldAllowSuitsFromItsIGame()
        {
            card.Suit = "Clubs";
            card.Suit.ShouldBe("Clubs");
        }

        [Test]
        public void ShouldAllowValuesFromItsIGame()
        {
            card.Value = "4";
            card.Value.ShouldBe("4");
        }

        [Test]
        public void ShouldPassCompareToOffToItsIGame()
        {
            game.Expect(g => g.Compare(null, null)).IgnoreArguments().Return(0);

            var card1 = new Card(game) { Suit = "Clubs", Value = "5" };
            var card2 = new Card(game) { Suit = "Clubs", Value = "5" };
            card1.CompareTo(card2).ShouldBe(0);

            game.AssertWasCalled(g => g.Compare(card1, card2), mo => mo.IgnoreArguments());
        }

        [Test]
        public void ShouldBeAbleToCheckValidity()
        {
            card.Suit = "Clubs";
            card.Value = "5";
            card.Validate().ShouldBeTrue();
        }

        [Test]
        public void ShouldImplementIValidate()
        {
            card.ShouldBeOfType<IValidate>();
        }
    }
}
