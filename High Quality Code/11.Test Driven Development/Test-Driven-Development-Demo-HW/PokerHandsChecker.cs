using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            bool isValid = true;
            if (hand.Cards.Count != 5)
            {
                isValid = false;
            }
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face && hand.Cards[i].Suit == hand.Cards[j].Suit)
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        public bool IsStraightFlush(IHand hand)
        {
            bool isHandValid = IsValidHand(hand);
            bool isStraight = IsStraight(hand);
            bool isFlush = IsFlush(hand);

            bool isStraightFlush = isHandValid && isStraight && isFlush;

            return isStraightFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            bool isHandValid = IsValidHand(hand);
            byte count = 1;
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        count++;
                    }
                }
                if (count == 4)
                {
                    break;
                }
                count = 0;
            }

            bool isFourCardsFromTheSameKind = false;
            if (isHandValid == true && count == 4)
            {
                isFourCardsFromTheSameKind = true;
            }

            return isFourCardsFromTheSameKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            bool isHandValid = IsValidHand(hand);
            bool areAllCardsTheSameColor = AreAllCardsTheSameColor(hand);

            bool isFlush = isHandValid && areAllCardsTheSameColor;

            return isFlush;
        }

        private static bool AreAllCardsTheSameColor(IHand hand)
        {
            bool areAllCardsTheSameColor = true;

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                if (hand.Cards[i].Suit != hand.Cards[i + 1].Suit)
                {
                    areAllCardsTheSameColor = false;
                    break;
                }
            }

            return areAllCardsTheSameColor;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
