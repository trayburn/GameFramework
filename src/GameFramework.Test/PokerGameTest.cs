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
    public class PokerGameTest : MockingBaseTest
    {
        private PokerGame game;

        public override void BeforeEachTest()
        {
            base.BeforeEachTest();
            game = new PokerGame();
        }

        [Test]
        public void ShouldBeAnIGame()
        {
            game.ShouldBeOfType<IGame>();
        }

        [Test]
        public void ShouldHaveTheProperNumberOfValues()
        {
            game.Values.Count.ShouldBe(13);
        }

        [Test]
        public void ShouldHaveTheProperSuits()
        {
            game.Suits.Contains("Spades").ShouldBeTrue();
            game.Suits.Contains("Clubs").ShouldBeTrue();
            game.Suits.Contains("Hearts").ShouldBeTrue();
            game.Suits.Contains("Diamonds").ShouldBeTrue();
        }

        [Test]
        public void ShouldReturnProperName()
        {
            game.GetName("Spades", "Ace").ShouldBe("Ace of Spades");
        }

        [Test]
        public void ShouldBeAbleToCompareTwoIdenticalCards()
        {
            var card1 = new Card(game) { Suit = "Spades", Value = "Two" };
            var card2 = new Card(game) { Suit = "Spades", Value = "Two" };
            game.Compare(card1, card2).ShouldBe(0);
        }

        [Test]
        public void ShouldBeAbleToCompareTwoSameValueCardsWithNonIdenticalSuits()
        {
            var card1 = new Card(game) { Suit = "Spades", Value = "Two" };
            var card2 = new Card(game) { Suit = "Diamonds", Value = "Two" };
            game.Compare(card1, card2).ShouldBe(0);
        }
        [Test]
        public void ShouldBeAbleToCompareTwoCardsWhereFirstIsGreater()
        {
            var card1 = new Card(game) { Suit = "Spades", Value = "Five" };
            var card2 = new Card(game) { Suit = "Spades", Value = "Two" };
            game.Compare(card1, card2).ShouldBe(1);
        }

        [Test]
        public void ShouldBeAbleToCompareTwoCardsWhereFirstIsLesser()
        {
            var card1 = new Card(game) { Suit = "Spades", Value = "Two" };
            var card2 = new Card(game) { Suit = "Spades", Value = "Five" };
            game.Compare(card1, card2).ShouldBe(-1);
        }

        [Test]
        public void ShouldCreateADeckBasedOnItsGame()
        {
            var deck = game.CreateDeck();
            deck.Game.ShouldBe(game);
        }

        [Test]
        public void ShouldCreateADeckWithFiftyTwoCards()
        {
            var deck = game.CreateDeck();
            deck.Count.ShouldBe(52);
        }

        [Test]
        public void ShouldOptionallyCreateAnEmptyDeck()
        {
            var deck = game.CreateDeck(false);
            deck.Count.ShouldBe(0);
        }
    }
}
