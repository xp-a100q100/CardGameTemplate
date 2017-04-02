using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    public class RuleType : Register<RuleOperator>
    {
        #region 构造和初始化
        RuleType() { test(); }

        static RuleType m_Instance = null;
        public static RuleType Instance
        {
            get
            {
                if (null == m_Instance)
                {
                    m_Instance = new RuleType();
                }
                return m_Instance;
            }
        }

        #endregion



        #region  信息管理


        void Register(string rule, string name = null)
        {
            object obj = Helper.Create(rule);
            if (null != obj)
            {
                RuleOperator rop = obj as RuleOperator;
                if (null != rop)
                {
                    Register(rop, name);
                }
                else
                {
                    throw new RegisterException("rule class " + rule + " is not belong class RuleOperator ");
                }
            }
            else
            {
                throw new RegisterException("rule class " + rule + " can not be create" );
            }
        }


        void Register(RuleOperator rule, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = rule.GetName();
            }
            AddRegister(name, rule);
        }


        public void test()
        {
            Register(new AttributeOperator(), "Attribute");
            Register(new CardOperator(), "Card");

        }

        #endregion

    }
}
