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
    public class PokerRulesTest : MockingBaseTest
    {
        [Test]
        public void ShouldCreateOnConstruction()
        {
            var rules = new PokerRules();
            rules.Deck.ShouldNotBeNull();
            rules.Deck.Count.ShouldBe(52);
            rules.Deck.Game.ShouldBeOfType<PokerGame>();
        }

        [Test]
        public void ShouldCreateAnEmptyDiscardPileOnConstruction()
        {
            var rules = new PokerRules();
            rules.DiscardDeck.ShouldNotBeNull();
            rules.DiscardDeck.Count.ShouldBe(0);
        }

        [Test]
        public void ShouldDealFivesCardsToEachPlayer()
        {
            var p1 = new Player();
            var p2 = new Player();
            var p3 = new Player();
            var p4 = new Player();
            var rules = new PokerRules();

            rules.Deal(p1, p2, p3, p4);

            p1.Hand.ShouldNotBeNull();
            p2.Hand.ShouldNotBeNull();
            p3.Hand.ShouldNotBeNull();
            p4.Hand.ShouldNotBeNull();

            rules.Deck.Count.ShouldBe(32);
        }

        [Test]
        public void ShouldPassComparerCallsToItsComparer()
        {
            IEnumerable<ICard> hand1 = null;
            IEnumerable<ICard> hand2 = null;
            var mock = Mock<IComparer<IEnumerable<ICard>>>();
            mock.Stub(c => c.Compare(null, null)).Return(0);

            var rules = new PokerRules(new PokerGame(), mock);
            rules.Compare(hand1, hand2);

            mock.AssertWasCalled(c => c.Compare(null, null));
        }
    }
}
