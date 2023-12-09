namespace AoC_2023.Solutions.Day07
{
    public class JokerHand : IComparable
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
            { 'J', 1 },
            { 'Q', 12 },
            { 'K', 13 },
            { 'A', 14 },

        };
        private string Cards = "";
        public HandType CurrentHandType;
        public int BidAmount;

        public JokerHand(string cards, int bidAmount)
        {
            Cards = cards;
            CurrentHandType = GetHandType(cards);
            BidAmount = bidAmount;
        }
        public static HandType GetHandType(string cards)
        {
            Dictionary<char, int> cardTypes;
            if (cards.Contains('J'))
            {
                cardTypes = cards
                    .Where(c => c != 'J')
                    .GroupBy(c => c)
                    .ToDictionary(g => g.Key, g => g.Count());
                var nbrJokers = cards.Where(c => c == 'J').Count();

                if (nbrJokers == 1)
                {
                    if (cardTypes.Values.Contains(4)) return HandType.FIVE_OF_A_KIND;
                    if (cardTypes.Values.Contains(3)) return HandType.FOUR_OF_A_KIND;
                    if (cardTypes.Values.Where(e => e == 2).Count() == 2) return HandType.FULL_HOUSE;
                    if (cardTypes.Values.Contains(2)) return HandType.THREE_OF_A_KIND;
                    return HandType.ONE_PAIR;
                }
                if (nbrJokers == 2)
                {
                    if (cardTypes.Values.Contains(3)) return HandType.FIVE_OF_A_KIND;
                    if (cardTypes.Values.Contains(2)) return HandType.FOUR_OF_A_KIND;
                    return HandType.THREE_OF_A_KIND;
                }
                if (nbrJokers == 3)
                {
                    if (cardTypes.Values.Contains(2)) return HandType.FIVE_OF_A_KIND;
                    return HandType.FOUR_OF_A_KIND;
                }
                return HandType.FIVE_OF_A_KIND;
            }
            cardTypes = cards
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
            JokerHand? other = obj as JokerHand;
            if (other == null) return -1;

            return CompareHand(other);
        }


        public int CompareHand(JokerHand other)
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
}
