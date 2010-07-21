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
    public class PokerHandComparerTest : MockingBaseTest
    {
        private PokerGame game;
        private PokerHandComparer comp;

        [SetUp]
        public void Setup()
        {
            game = new PokerGame();
            comp = new PokerHandComparer(game);
        }

        [Test]
        public void AceHighBeatsAllOtherSingleCardsExceptAces()
        {
            var aceHigh = new List<ICard> { NewCard("Spades","Ace") };

            var testSuits = game.Suits;
            var testValues = game.Values.Where(v => v != "Ace");

            testSuits.Do(s => testValues.Do(v =>
            {
                var hand = new List<ICard> { NewCard(s, v) };
                Assert.AreEqual(-1, comp.Compare(hand, aceHigh));
            }));
        }

        private ICard NewCard(string suit, string value)
        {
            return new Card(game) { Suit = suit, Value = value };
        }
    }
}
