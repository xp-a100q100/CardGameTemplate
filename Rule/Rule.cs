using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardGame
{
    public static class Rule
    {
        #region parser

        static public RuleObject Parser(string ruleType, List<string> content)
        {
            ParserData dt = RuleType.Instance.GetRegister(ruleType).Parser(content);
            RuleObject rb = new RuleObject()
            {
                m_data = dt,
                m_ruleType = ruleType
            };
            return rb;
        }

        static public List<Card> Compute(RuleObject obj)
        {
            List<Card> cardList = new List<Card>();

            if (null == obj || null == obj.m_data || string.IsNullOrEmpty(obj.m_ruleType))
            {
                return cardList;
            }

            RuleOperator r = RuleType.Instance.GetRegister(obj.m_ruleType);

            if (null == r)
            {
                return cardList;
            }

            cardList = r.runParser(obj.m_data) as List<Card>;

            return cardList;
        }

        static public List<Card> ComputeParser(string ruleType, List<string> content)
        {
            return Compute(Parser(ruleType, content));
        }

        #endregion


    }

















}

