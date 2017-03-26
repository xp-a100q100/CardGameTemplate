using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class AttributeOperator : RuleOperator
    {

        #region 实现父类继承

        protected virtual void  init()
        {
            AddRegister("*", multiply, 1);
            AddRegister("+", add, 0);
        }

        #endregion


        #region 功能模块

        void multiply()
        {
            var attrs = m_param as List<string>;
            checkParam(attrs, multiply);

            List<Card> cardlist = new List<Card>();
            var info = CardManager.Instance.m_attribute.GetRegisterObj();

            foreach (var attr in attrs)
            {
                List<Card> cachelist = new List<Card>();
                foreach (var it in info[attr])
                {
                    if (0 == cardlist.Count)
                    {
                        Card c = new Card();
                        c.m_attribute.AddRegister(attr, it);
                        cachelist.Add(c);
                    }
                    else
                    {
                        foreach (var card in cardlist)
                        {
                            Card c = new Card(card);
                            c.m_attribute.AddRegister(attr, it);
                            cachelist.Add(c);
                        }
                    }
                }
                cardlist = cachelist;
            }
            m_result = cardlist as object;

        }

        void add()
        {
            var attrs = m_param as List<string>;
            checkParam(attrs, add);

            List<Card> cardlist = new List<Card>();
            var info = CardManager.Instance.m_attribute.GetRegisterObj();

            foreach (var attr in attrs)
            {
                foreach (var it in info[attr])
                {
                    Card c = new Card();
                    c.m_attribute.AddRegister(attr, it);
                    cardlist.Add(c);
                }
            }
            m_result = cardlist as object;

        }


        #endregion


    }


}
