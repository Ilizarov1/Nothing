using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace newCard
{
    public class cards:CollectionBase,ICloneable//定义（集合）cards类
    {
        public void Add(Card newCard)//重写添加
        {
            List.Add(newCard);
        }

        public void Remove(Card oldCard)//重写移除最后一张
        {
            List.Remove(oldCard);
        }

        public cards() { }//默认构造

        public Card this[int CardIndex]//属性card，定义了一个索引符
        {
            get
            {
                return (Card)List[CardIndex];
            }
            set
            {
                List[CardIndex] = value;
            }
        }

        public void CopyTo(cards targetCards)//复制方法,利用索引符
        {
            for(int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }

        public bool Contains(Card card)//确定是否有某张卡
        {
            return InnerList.Contains(card);
        }

        public object Clone()
        {
            cards newCards = new cards();
            foreach(Card sourceCard in List)
            {
                newCards.Add(sourceCard.Clone() as Card);
            }
            return newCards;
        }
    }
}
