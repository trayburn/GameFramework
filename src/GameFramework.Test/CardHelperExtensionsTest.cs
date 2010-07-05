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
    public class CardHelperExtensionsTest : MockingBaseTest
    {
        [Test]
        public void ShouldAcceptACardForGetNameOnIGame()
        {
            var game = new PokerGame();
            var card = new Card(game) { Suit = "Spades", Value = "Ten" };
            game.GetName(card).ShouldBe("Ten of Spades");
        }
    }
}
