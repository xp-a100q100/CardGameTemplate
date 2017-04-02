using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class AttributeAdd : OperatorBase
    {
        new public const string Name = "+";
        new public const int m_v_dim = 2;
    
        #region  构造和初始化
        public AttributeAdd(RuleOperator belong, string name = AttributeAdd.Name,
            int dim = AttributeAdd.m_v_dim)
            : base(belong, name, m_v_dim)
        {

        }
        #endregion


        #region  功能相关

        public override object run(object obj)
        {

            List<object> objlst = obj as List<object>;
            if (null == objlst) return null;
            List<Card> cardlist = new List<Card>();

            foreach (var it in objlst)
            {
                if (null == it) continue;
                if (typeof(string) == it.GetType())
                {
                    cardlist.AddRange(AttributeOperator.GetCardList(it as string));
                }
                else if (typeof(List<Card>) == it.GetType())
                {
                    cardlist.AddRange(it as List<Card>);
                }
                else if (typeof(ParserData) == it.GetType())
                {
                    cardlist.AddRange(m_parent.runParser(it as ParserData) as List<Card>);
                }
                else
                {

                }
            }
            return cardlist;






            //var attrs = obj as List<string>;
            //m_parent.checkParam(attrs, this);

            //List<Card> cardlist = new List<Card>();
            //var info = CardManager.Instance.GetRegisterObj();

            //foreach (var attr in attrs)
            //{
            //    foreach (var it in info[attr])
            //    {
            //        Card c = new Card();
            //        c.AddRegister(attr, it);
            //        cardlist.Add(c);
            //    }
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
