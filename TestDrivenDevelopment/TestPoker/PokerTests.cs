namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;


    // Impelemented some logic for CompareHands method but no test for it yet!!!
    [TestClass]
    public class PokerTests
    {
        private IHand hand;
        private IPokerHandsChecker checker;

        [TestInitialize]
        public void InitializeHandAndChecker()
        {
            hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            checker = new PokerHandsChecker();
        }

        [TestMethod]
        public void TestIfValidHandCount()
        {
            hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
            });

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIfCardsInHandAreSame()
        {
            hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
            });

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestIfStraightFlush()
        {
            hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

            Assert.IsTrue(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestIfFourOfKind()
        {
            hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            var handTwo = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
            });

            Assert.IsTrue(checker.IsFourOfAKind(hand) && checker.IsFourOfAKind(handTwo));
        }

        [TestMethod]
        public void TestIfHandIsFullHouse()
        {
            hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            var anotherHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
            });

            Assert.IsTrue(checker.IsFullHouse(hand) && checker.IsFullHouse(anotherHand));
        }

        [TestMethod]
        public void TestIfFlush()
        {
            hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
            });

            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void TestIfStraight()
        {
            hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
            });

           var smallStraight = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
            });

            Assert.IsTrue(checker.IsStraight(hand) && checker.IsStraight(smallStraight));
        }

        [TestMethod]
        public void TestIfThreeOfKind()
        {
            hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            var secondHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            var thirdHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            Assert.IsTrue(checker.IsThreeOfAKind(hand) && 
                          checker.IsThreeOfAKind(secondHand) && 
                          checker.IsThreeOfAKind(thirdHand));
        }

        [TestMethod]
        public void TestIfIsTwoPair()
        {
            hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
            });

            Assert.IsTrue(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestIfIsOnePair()
        {
            hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
            });

            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestIfIsHighCard()
        {
            hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            Assert.IsTrue(checker.IsHighCard(hand));
        }
    }
}
