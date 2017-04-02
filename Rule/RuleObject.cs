using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    
    public class RuleObject
    {
        //public List<object> m_param = new List<object>();
        //public RuleOperatorObject m_operator = new RuleOperatorObject();
        //bool m_canBeParser = true;

        public ParserData m_data;
        public string m_ruleType;
    }

    public class RuleOperatorObject
    {
        public string m_ruleType;
        public string m_ruleFunc;
    }


}
