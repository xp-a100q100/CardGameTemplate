using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card
    {
        public Register<string> m_attribute = new Register<string>();
        #region 构造函数
        public Card()
        {

        }
        public Card(Card that)
        {
            m_attribute.SetRegisterObj(that.m_attribute.GetRegisterObj());
        }
        public Card(Dictionary<string, string> attrs)
        {
            m_attribute.SetRegisterObj(attrs);
        }
        #endregion




    }
}
