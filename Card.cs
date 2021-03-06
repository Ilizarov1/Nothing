﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace newCard
{
    public class Card:ICloneable
    {
        public readonly Suit suit;
        public readonly Rank rank;
        private Card()
        {
           
        }

        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
           
        }

        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
            
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}