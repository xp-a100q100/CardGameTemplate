using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class OperatorBase
    {
        string m_name = "";

        protected RuleOperator m_parent = new RuleOperator();

        public const string Name = "OperatorBase";
        #region  构造和初始化
        public OperatorBase(RuleOperator belong,
            string name = OperatorBase.Name,
            int dim = OperatorBase.m_v_dim)
        {
            m_parent = belong;
            m_name = name;
            Dim = dim;
        }
        public string GetName()
        {
            return this.m_name;
        }

        #endregion


        #region 设置属性
        public const int m_v_dim = 0;
        int m_dim = 0;
        public int Dim
        {
            get
            {
                return m_dim;
            }
            set
            {
                m_dim = value;
            }
        }
        #endregion

        #region  功能相关

        public virtual object run(object obj)
        {
            return null;
        }

        #endregion

        #region 解析相关类

        public virtual RuleObject Parser(string content)
        {
            return null;
        }

        #endregion

    }
}
