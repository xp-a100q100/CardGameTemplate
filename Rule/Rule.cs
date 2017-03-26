using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardGame
{
    static public class Rule
    {
        #region register

        static Dictionary<string, RuleOperatorObject> m_register = new Dictionary<string, RuleOperatorObject>();

        public static void InitRegister()
        {

        }

        public static void Add(string key, RuleOperatorObject value)
        {
            m_register[key] = value;
        }
        public static RuleOperatorObject Get(string key)
        {
            if (m_register.ContainsKey(key))
            {
                return m_register[key];
            }
            return new RuleOperatorObject();
        }
        public static void Remove(string key)
        {
            if (m_register.ContainsKey(key))
            {
                m_register.Remove(key);
            }
        }

        #endregion

        #region parser


        public RuleObject Parser(string ruleType, List<string> content)
        {
            return null;
        }



        #endregion


    }

















}

