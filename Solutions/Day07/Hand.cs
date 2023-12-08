using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023.Solutions.Day7
{
    public class Hand : IComparable
    {
        private static readonly Dictionary<char, int> CardValueMap = new()
        {
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'T', 10 },
            { 'J', 11 },
            { 'Q', 12 },
            { 'K', 13 },
            { 'A', 14 },

        };
        private string Cards = "";
        public HandType CurrentHandType;
        public int BidAmount;

        public Hand(string cards, int bidAmount)
        {
            Cards = cards;
            CurrentHandType = GetHandType(cards);
            BidAmount = bidAmount;
        }
        public static HandType GetHandType(string cards)
        {

            Dictionary<char, int> cardTypes = cards
                .GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count());
            if (cardTypes.Values.Contains(5)) return HandType.FIVE_OF_A_KIND;
            if (cardTypes.Values.Contains(4)) return HandType.FOUR_OF_A_KIND;
            if (cardTypes.Values.Contains(3) && cardTypes.Values.Contains(2)) return HandType.FULL_HOUSE;
            if (cardTypes.Values.Contains(3)) return HandType.THREE_OF_A_KIND;
            if (cardTypes.Values.Where(e => e == 2).Count() == 2) return HandType.TWO_PAIR;
            if (cardTypes.Values.Contains(2)) return HandType.ONE_PAIR;
            return HandType.HIGH_CARD; 
        }

        public override string ToString()
        {
            return $"Hand: {this.Cards}, bid {BidAmount}";
        }

        public int CompareTo(object? obj)
        {

            if (obj == this) return 1;
            Hand? other = obj as Hand;
            if (other == null) return -1;

            return CompareHand(other);
        }


        public int CompareHand(Hand other)
        {
            if ((int)other.CurrentHandType > (int)CurrentHandType)
            {
                return -1;
            }
            if ((int)other.CurrentHandType < (int)CurrentHandType)
            {
                return 1;
            }
            var cardIdx = 0;
            int thisCard;
            int otherCard;
            while (cardIdx < this.Cards.Length)
            {
                thisCard = CardValueMap[this.Cards[cardIdx]];
                otherCard = CardValueMap[other.Cards[cardIdx]];
                if (thisCard > otherCard) return 1;
                if (thisCard < otherCard) return -1;
                cardIdx++;
            }
            return 0;
            //// Same handtype
            //switch (CurrentHandType)
            //{
            //    case HandType.HIGH_CARD:
            //        return CompareHighCards(this.Cards, other.Cards);
            //    case HandType.ONE_PAIR:
            //        var thisPairChar = GetCardOccuringTimes(this.Cards, 2);
            //        var otherPairChar = GetCardOccuringTimes(other.Cards, 2);
            //        if (CardValueMap[thisPairChar] > CardValueMap[otherPairChar]) return 1;
            //        if (CardValueMap[thisPairChar] < CardValueMap[otherPairChar]) return -1;
            //        var thisRemainingCards = this.Cards.Where(e => e != thisPairChar).ToString();
            //        var otherRemainingCards = other.Cards.Where(e => e != thisPairChar).ToString();
            //        return CompareHighCards(thisRemainingCards, otherRemainingCards);
            //    case HandType.TWO_PAIR:
            //        thisPairChar = this.Cards.OrderBy(e => CardValueMap[e]).Take(1).First();
            //        otherPairChar = other.Cards.OrderBy(e => CardValueMap[e]).Take(1).First();
            //        if (CardValueMap[thisPairChar] > CardValueMap[otherPairChar]) return 1;
            //        if (CardValueMap[thisPairChar] < CardValueMap[otherPairChar]) return -1;
            //        thisPairChar = this.Cards.OrderBy(e => CardValueMap[e]).Skip(2).Take(1).First();
            //        otherPairChar = other.Cards.OrderBy(e => CardValueMap[e]).Skip(2).Take(1).First();
            //        if (CardValueMap[thisPairChar] > CardValueMap[otherPairChar]) return 1;
            //        return CompareHighCards(
            //            this.Cards.OrderBy(e => CardValueMap[e]).Skip(4).Take(1).First().ToString(),
            //            other.Cards.OrderBy(e => CardValueMap[e]).Skip(4).Take(1).First().ToString());
            //    case HandType.THREE_OF_A_KIND:
            //        thisPairChar = this.Cards.OrderBy(e => CardValueMap[e]).Take(1).First();
            //        otherPairChar = other.Cards.OrderBy(e => CardValueMap[e]).Take(1).First();
            //        if (CardValueMap[thisPairChar] > CardValueMap[otherPairChar]) return 1;
            //        if (CardValueMap[thisPairChar] < CardValueMap[otherPairChar]) return -1;
            //        return CompareHighCards(
            //            this.Cards.OrderBy(e => CardValueMap[e]).Skip(3).Take(2).ToString(),
            //            other.Cards.OrderBy(e => CardValueMap[e]).Skip(3).Take(2).ToString());
            //    case HandType.FULL_HOUSE:
            //        return 1;
            //    case HandType.FOUR_OF_A_KIND:
            //        return 1;
            //    case HandType.FIVE_OF_A_KIND:
            //        return CompareHighCards(this.Cards, other.Cards);
            //    default:
            //        return 1;
            //}
        }
        public char GetCardOccuringTimes(string cards, int occuring)
        {
            foreach (var c in cards)
            {
                if (cards.Where(e => e == c).Count() == occuring)
                {
                    return c;
                }
            }
            throw new NotImplementedException();
        }

        public int CompareHighCards(string cards1, string cards2)
        {
            var sortedCards1 = cards1.Select(e => CardValueMap[e]).OrderDescending();
            var sortedCards2 = cards2.Select(e => CardValueMap[e]).OrderDescending();
            var idx = 0;
            while (idx < sortedCards1.Count())
            {
                var max1 = sortedCards1.Skip(idx).First();
                var max2 = sortedCards2.Skip(idx).First();
                if (max1 > max2)
                {
                    return 1;
                }
                if (max1 < max2)
                {
                    return -1;
                }
            }
            return 0;
        }

    }

    public enum HandType
    {
        HIGH_CARD = 0,
        ONE_PAIR = 1,
        TWO_PAIR = 2,
        THREE_OF_A_KIND = 3,
        FULL_HOUSE = 4,
        FOUR_OF_A_KIND = 5,
        FIVE_OF_A_KIND = 6,
    }
}
