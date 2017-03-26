using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    public static class CardManager
    {
        #region 属性管理
        static Dictionary<string, List<string>> m_attribute = new Dictionary<string, List<string>>();

        public static void AddAttribute(string attr, List<string> value)
        {
            m_attribute[attr] = value;
        }
        public static List<string> GetAttribute(string attr)
        {
            if (m_attribute.ContainsKey(attr))
            {
                return m_attribute[attr];
            }
            return new List<string>();
        }
        public static void RemoveAttribute(string attr)
        {
            if (m_attribute.ContainsKey(attr))
            {
                m_attribute.Remove(attr);
            }
        }

        #endregion

        public static List<Card> MakeCards(List<string> attrs, List<string> rule)
        {

            //******************************************************************************


















            //******************************************************************************


            //去重
            attrs = new List<string>(attrs.Where((x, i) => attrs.FindIndex(z => z == x) == i));

            List<Card> cardlist = new List<Card>();
            List<string> permissions = new List<string>();
            foreach (var attr in attrs)
            {
                if (!m_attribute.ContainsKey(attr))
                {
                    throw new Exception("Card make failed, Attribute " + attr + " is not exist, please check it");
                }
                List<Card> cachelist = new List<Card>();
                foreach (var it in m_attribute[attr])
                {
                    if (0 == cardlist.Count)
                    {
                        cachelist.Add(new Card().AddAttribute(attr, it));
                    }
                    else
                    {
                        foreach (var card in cardlist)
                        {
                            cachelist.Add(new Card(card).AddAttribute(attr, it));
                        }
                    }
                }
                cardlist = cachelist;
            }
            return cardlist;



            //******************************************************************************


        }



        public static void test()
        {
            AddAttribute("花色", new List<string>() { 
                "黑桃","红桃","梅花","方块"
            });
            AddAttribute("数值", new List<string>() { 
                "1","2","3","4","5","6","7","8","9","10","J","Q","K"
            });
            AddAttribute("王牌", new List<string>() { 
            "大王","小王"
            });
        }

    }


}
