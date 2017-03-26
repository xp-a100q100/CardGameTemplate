using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card
    {
        Dictionary<string, string> m_attribute = new Dictionary<string,string>();

        #region 构造函数
        public Card()
        {

        }
        public Card(Card that)
        {
            this.SetAttribute(that.GetAttribute());
        }
        public Card(Dictionary<string, string> attrs)
        {
            this.SetAttribute(attrs);
        }
        #endregion


        #region 属性管理
        public Card SetAttribute(Dictionary<string, string> attr)
        {
            if (null != attr)
            {
                m_attribute = attr;
            }
            return this;
        }
        public Dictionary<string, string> GetAttribute()
        {
            return new Dictionary<string, string>(m_attribute);
        }

        public Card AddAttribute(string attr, string value)
        {
            m_attribute[attr] = value;
            return this;
        }
        public string GetAttribute(string attr)
        {
            if (m_attribute.ContainsKey(attr))
            {
                return m_attribute[attr];
            }
            return "";
        }
        public Card RemoveAttribute(string attr)
        {
            if (m_attribute.ContainsKey(attr))
            {
                m_attribute.Remove(attr);
            }
            return this;
        }

        #endregion


    }
}
