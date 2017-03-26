using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    ////Enum.TryParse(RuleType, true, "rule_attribute");
    //public enum RuleType
    //{
    //    rule_null,
    //    rule_attribute,
    //    rule_object
    //};

    class RuleType
    {

        #region register

        static Dictionary<string, RuleOperator> m_register = new Dictionary<string, RuleOperator>();

        public static void InitRegister()
        {

        }

        public static void Add(string key, RuleOperator value)
        {
            m_register[key] = value;
        }
        public static RuleOperator Get(string key)
        {
            if (m_register.ContainsKey(key))
            {
                return m_register[key];
            }
            return new RuleOperator();
        }
        public static void Remove(string key)
        {
            if (m_register.ContainsKey(key))
            {
                m_register.Remove(key);
            }
        }

        #endregion







    }
}
