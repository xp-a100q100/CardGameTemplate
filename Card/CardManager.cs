using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    public class CardManager
    {
        #region 构造和初始化

        CardManager() { }

        static CardManager m_Instance = null;
        public static CardManager Instance
        {
            get {
                if (null == m_Instance)
                {
                    m_Instance = new CardManager();
                }
                return m_Instance; 
            }
        }

        #endregion

        #region 信息管理
        public Register<List<string>> m_attribute = new Register<List<string>>();
        #endregion

        #region 功能函数
        public List<Card> MakeCards(List<string> attrs, List<string> rule)
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
                foreach (var it in m_attribute.GetRegisterObj()[attr])
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
            return cardlist;



            //******************************************************************************


        }

        #endregion

        #region 测试样例

        public void test()
        {
            m_attribute.AddRegister("花色", new List<string>() { 
                "黑桃","红桃","梅花","方块"
            });
            m_attribute.AddRegister("数值", new List<string>() { 
                "1","2","3","4","5","6","7","8","9","10","J","Q","K"
            });
            m_attribute.AddRegister("王牌", new List<string>() { 
            "大王","小王"
            });

            string rule = "花色*数值+王牌";


        }

        #endregion
    }


}
