using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    
    public class RuleObject
    {
        public List<string> m_attribute;
        public List<RuleObject> m_rule_object;
        public List<Card> m_card_object;
        public RuleOperatorObject m_operator;
    }

    public class RuleOperatorObject
    {
        public string m_ruleType;
        public string m_ruleFunc;
    }






}
