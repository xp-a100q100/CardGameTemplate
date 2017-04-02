using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    public class CardManager : Register<List<string>>
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
        #endregion

        #region 功能函数
        public List<Card> MakeCards(List<string> rule)
        {
            return Rule.ComputeParser("Attribute", rule);
        }

        #endregion

        #region 测试样例

        public void test()
        {
            AddRegister("花色", new List<string>() { 
                "黑桃","红桃","梅花","方块"
            });
            AddRegister("数值", new List<string>() { 
                "1","2","3","4","5","6","7","8","9","10","J","Q","K"
            });
            AddRegister("王牌", new List<string>() { 
            "大王","小王"
            });

            string rule = "花色*数值+王牌";

            var result = MakeCards(new List<string>() { rule });

            foreach (var it in result)
            {
                foreach (var nd in it.Keys(true))
                {
                    Console.Write(nd + " : " + it.GetRegister(nd) + "\t");
                }
                Console.Write("\n");
            }
        }

        #endregion
    }


}
