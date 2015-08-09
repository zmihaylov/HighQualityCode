using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            StringBuilder hand = new StringBuilder();

            hand.AppendLine("Hand: ");
            hand.Append(string.Join("\n", this.Cards));

            return hand.ToString();
        }
    }
}
