using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    
    public class RuleObject
    {
        public List<string> m_attribute = new List<string>();
        public List<RuleObject> m_rule_object = new List<RuleObject>();
        public List<Card> m_card_object = new List<Card>();
        public RuleOperatorObject m_operator = new RuleOperatorObject();
    }

    public class RuleOperatorObject
    {
        public string m_ruleType;
        public string m_ruleFunc;
    }






}
