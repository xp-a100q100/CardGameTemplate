using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class AttributeMultiply : OperatorBase
    {
        new public const string Name = "*";
        new public const int m_v_dim = 2;
    
        #region  构造和初始化
        public AttributeMultiply(RuleOperator belong, string name = AttributeMultiply.Name,
            int dim = AttributeMultiply.m_v_dim)
            : base(belong, name, m_v_dim)
        {

        }
        #endregion


        #region  功能相关

        public override object run(object obj)
        {
            List<object> objlst = obj as List<object>;
            if (null == objlst) return null;
            List<List<Card>> cardlist = new List<List<Card>>();
 
            foreach ( var it in objlst)
            {
                if (null == it) continue;
                if (typeof(string) == it.GetType())
                {
                    cardlist.Add(AttributeOperator.GetCardList(it as string));
                }
                else if (typeof(List<Card>) == it.GetType())
                {
                    cardlist.Add(it as List<Card>);
                }
                else if (typeof(ParserData) == it.GetType())
                {
                    cardlist.Add(m_parent.runParser(it as ParserData) as List<Card>);
                }
                else
                {

                }
            }
            return CardOperator.multiply(cardlist);


            //var attrs = obj as List<string>;
            //m_parent.checkParam(attrs, this);

            //List<Card> cardlist = new List<Card>();
            //var info = CardManager.Instance.GetRegisterObj();

            //foreach (var attr in attrs)
            //{
            //    List<Card> cachelist = new List<Card>();
            //    foreach (var it in info[attr])
            //    {
            //        if (0 == cardlist.Count)
            //        {
            //            Card c = new Card();
            //            c.AddRegister(attr, it);
            //            cachelist.Add(c);
            //        }
            //        else
            //        {
            //            foreach (var card in cardlist)
            //            {
            //                Card c = new Card(card);
            //                c.AddRegister(attr, it);
            //                cachelist.Add(c);
            //            }
            //        }
            //    }
            //    cardlist = cachelist;
            //}
            //return cardlist as object;
        }


        #endregion

        #region 解析相关类

        public override RuleObject Parser(string content)
        {

            return null;
        }

        #endregion




    }



}
