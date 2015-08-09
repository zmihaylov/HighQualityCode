using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            bool cardsAreDifferent = true;

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face && hand.Cards[i].Suit == hand.Cards[j].Suit)
                    {
                        cardsAreDifferent = false;
                    }
                }
            }

            if (cardsAreDifferent && hand.Cards.Count == 5)
            {
                return true;
            }

            return false;
        }

        public bool IsStraightFlush(IHand hand)
        {
            bool isFlush = this.CheckForFlush(hand);

            bool isStraight = this.CheckForStraight(hand);

            if (isStraight && isFlush)
            {
                return true;
            }

            return false;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            var cards = this.GetCardsFaceInInt(hand);

            bool isFourOfKindLeft = true;
            bool isFourOfKindRight = true;

            for (int i = 1; i < cards.Count - 1; i++)
            {
                if (cards[i] != cards[i + 1])
                {
                    isFourOfKindRight = false;
                }
            }

            for (int i = 0; i < cards.Count - 2; i++)
            {
                if (cards[i] != cards[i + 1])
                {
                    isFourOfKindLeft = false;
                }
            }

            if (isFourOfKindLeft || isFourOfKindRight)
            {
                return true;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            bool hasThreeOfKind = this.CheckForThreeOfKind(hand);
            int numberOfPairs = this.GetCountOfPairs(hand);

            if (hasThreeOfKind && numberOfPairs == 1)
            {
                return true;
            }

            return false;
        }

        public bool IsFlush(IHand hand)
        {
            return this.CheckForFlush(hand);
        }

        public bool IsStraight(IHand hand)
        {
            return this.CheckForStraight(hand);
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            return this.CheckForThreeOfKind(hand);
        }

        public bool IsTwoPair(IHand hand)
        {
            return this.GetCountOfPairs(hand) == 2;
        }

        public bool IsOnePair(IHand hand)
        {
            return this.GetCountOfPairs(hand) == 1;
        }

        public bool IsHighCard(IHand hand)
        {
            var pairs = this.GetCountOfPairs(hand);

            if (pairs == 0 && !this.IsThreeOfAKind(hand) &&
                              !this.IsFlush(hand) &&
                              !this.IsStraight(hand))
            {
                return true;
            }

            return false;
        }

        // TODO: Logic is not full for one and two pairs and three of a kind if you play Texas Hold'em
        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            var firstHandStrength = GetHandStrength(firstHand);
            var secondHandStrength = GetHandStrength(secondHand);

            if (firstHandStrength > secondHandStrength)
            {
                return 1;
            }
            else if (firstHandStrength < secondHandStrength)
            {
                return -1;
            }
            else
            {
                var firstHandCards = GetCardsFaceInInt(firstHand);
                var secondHandCards = GetCardsFaceInInt(secondHand);

                if (firstHandStrength == 1 ||
                    firstHandStrength == 5 ||
                    firstHandStrength == 6 ||
                    firstHandStrength == 9)
                {
                    if (firstHandCards[4] > secondHandCards[4])
                    {
                        return 1;
                    }
                    else if (firstHandCards[4] < secondHandCards[4])
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (firstHandStrength == 2)
                {
                    var firstHandPairStrength = GetPairStrength(firstHandCards, 2);
                    var secondHandPairStrength = GetPairStrength(secondHandCards, 2);

                    return GetResult(firstHandPairStrength, secondHandPairStrength);
                }
                else if (firstHandStrength == 3)
                {
                    if (firstHandCards[3] == secondHandCards[3])
                    {
                        if (firstHandCards[1] == secondHandCards[1])
                        {
                            return 0;
                        }
                        else if (firstHandCards[1] > secondHandCards[1])
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        if (firstHandCards[3] > secondHandCards[3])
                        {
                            return 1;
                        }
                        else if (firstHandCards[3] < secondHandCards[3])
                        {
                            return -1;
                        }
                    }
                }
                else if (firstHandStrength == 4)
                {
                    var firstHandThreeStrength = GetPairStrength(firstHandCards, 3);
                    var secondHandThreeStrength = GetPairStrength(secondHandCards, 3);

                    return GetResult(firstHandThreeStrength, secondHandThreeStrength);
                }
                else if (firstHandStrength == 8)
                {
                    var firstHandFourStrength = GetPairStrength(firstHandCards, 4);
                    var secondHandFourStrength = GetPairStrength(secondHandCards, 4);

                    return GetResult(firstHandFourStrength, secondHandFourStrength);
                }
                else if (firstHandStrength == 7)
                {
                    var firstHandPairStrength = GetPairStrength(firstHandCards, 2);
                    var secondHandPairStrength = GetPairStrength(secondHandCards, 2);

                    var firstHandThreeStrength = GetPairStrength(firstHandCards, 3);
                    var secondHandThreeStrength = GetPairStrength(secondHandCards, 3);

                    if (firstHandThreeStrength == secondHandThreeStrength)
                    {
                        return GetResult(firstHandPairStrength, secondHandPairStrength);
                    }
                    else
                    {
                        return GetResult(firstHandThreeStrength, secondHandThreeStrength);
                    }
                }
            }

            return 0;
        }

        private int GetResult(int firstHandPairStrength, int secondHandPairStrength)
        {
            if (firstHandPairStrength > secondHandPairStrength)
            {
                return 1;
            }
            else if (firstHandPairStrength < secondHandPairStrength)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private int GetPairStrength(List<int> cards, int numberOfCards)
        {
            return cards.GroupBy(c => c)
                        .Where(g => g.Count() == numberOfCards)
                        .Select(y => y.Key)
                        .ToList()
                        .FirstOrDefault();
        }

        private int GetHandStrength(IHand hand)
        {

            if (this.IsStraightFlush(hand))
            {
                return 9;
            }
            else if (this.IsFourOfAKind(hand))
            {
                return 8;
            }
            else if (this.IsFullHouse(hand))
            {
                return 7;
            }
            else if (this.IsFlush(hand))
            {
                return 6;
            }
            else if (this.IsStraight(hand))
            {
                return 5;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                return 4;
            }
            else if (this.IsTwoPair(hand))
            {
                return 3;
            }
            else if (this.IsOnePair(hand))
            {
                return 2;
            }
            else if (this.IsHighCard(hand))
            {
                return 1;
            }

            return 0;
        }

        private int GetCountOfPairs(IHand hand)
        {
            var cards = GetCardsFaceInInt(hand)
                .GroupBy(c => c);
            int countOfPairs = 0;

            foreach (var group in cards)
            {
                if (group.Count() == 2)
                {
                    countOfPairs++;
                }
            }

            return countOfPairs;
        }

        private bool CheckForThreeOfKind(IHand hand)
        {
            var cards = GetCardsFaceInInt(hand);

            bool threeOfKindLeft = true;
            bool threeOfKindMiddle = true;
            bool threeOfKindRight = true;

            for (int i = 0; i < cards.Count - 3; i++)
            {
                if (cards[i] != cards[i + 1])
                {
                    threeOfKindLeft = false;
                }
            }

            for (int i = 1; i < cards.Count - 2; i++)
            {
                if (cards[i] != cards[i + 1])
                {
                    threeOfKindMiddle = false;
                }
            }

            for (int i = 2; i < cards.Count - 1; i++)
            {
                if (cards[i] != cards[i + 1])
                {
                    threeOfKindRight = false;
                }
            }

            if (threeOfKindLeft || threeOfKindMiddle || threeOfKindRight)
            {
                return true;
            }

            return false;
        }

        private bool CheckForStraight(IHand hand)
        {
            var cards = GetCardsFaceInInt(hand);

            bool isStraight = true;

            if (cards[4] == 14 && cards[0] == 2)
            {
                for (int i = 0; i < cards.Count - 2; i++)
                {
                    if (cards[i] != cards[i + 1] - 1)
                    {
                        isStraight = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < cards.Count - 1; i++)
                {
                    if (cards[i] != cards[i + 1] - 1)
                    {
                        isStraight = false;
                    }
                }
            }

            return isStraight;
        }

        private List<int> GetCardsFaceInInt(IHand hand)
        {
            return hand.Cards
                .Select(c => (int)c.Face)
                .OrderBy(c => c)
                .ToList();
        }

        private bool CheckForFlush(IHand hand)
        {
            bool isFlush = true;

            var firstCard = hand.Cards[0];

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (firstCard.Suit != hand.Cards[i].Suit)
                {
                    isFlush = false;
                }
            }

            return isFlush;
        }
    }
}
