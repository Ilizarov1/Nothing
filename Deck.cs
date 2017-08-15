using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace newCard
{
    public class Deck:ICloneable
    {
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as cards);
            return newDeck;
        }

        private Deck(cards newCards)
        {
            cards = newCards;
        }

        private cards cards = new cards();

        public Deck()//构造，建一副新牌
        {
            for(int suitVal = 0; suitVal < 4; suitVal++)
            {
                for(int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }

        public Card GetCard(int cardNum) //方法，获取牌
        {
            if (cardNum >= 0 && cardNum <= 51)
                return cards[cardNum];
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "value must be between 0 and 51"));//越界
           
        }

        public void Shuffle()//方法，洗牌
        {
            cards newDeck = new cards();
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();
            for(int i = 0; i < 52; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(52);//取一个随机数
                    if (assigned[sourceCard] == false)//检验随机数，跳出循环
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);//把原来套牌中的卡给空数组
            }
            newDeck.CopyTo(cards);//复制到cards中，实现洗牌
          
        }
    }
}