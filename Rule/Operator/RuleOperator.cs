using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class RuleOperator
    {
        #region  构造和初始化
        public RuleOperator()
        {
            init();
        }
        public string GetName()
        {
            return this.GetType().Name;
        }


        #endregion

        #region  子類需要實現函數

        protected virtual void init() 
        {

        }

        #endregion

        #region 注册信息相关

        Register<Action> m_attribute = new Register<Action>();
        Register<Action, int> m_level = new Register<Action, int>();

        public void AddRegister(string key, Action act, int level = 0)
        {
            m_attribute.AddRegister(key, act);
            SetLevel(act, level);
        }
        public void SetLevel(Action act, int level)
        {
            m_level.AddRegister(act, level);
        }
        public int GetLevel(string key)
        {
            Action act = m_attribute.GetRegister(key);
            if (act == default(Action))
            {
                throw new RuntimeException("can not find rule level " + key + ", please register it first");
            }
            int lvl = m_level.GetRegister(act);
            if (lvl == default(int))
            {
                throw new RuntimeException("can not find rule level " + key + ", please check you code to set level");
            }
            return lvl;
        }


        #endregion


        #region 参数检查
        protected void checkParam(List<string> attrs, Action act)
        {
            string label = "";
            if (string.IsNullOrEmpty(m_attribute.FindFirstKeyWithValue(act)))
            {
                throw new RegisterException(GetName(), "no register function", act.GetType().Name, "");
            }


            if (null == attrs)
            {
                throw new RuntimeException(GetName(), "run function", label, "params is correct");
            }

            //去重
            attrs = Helper.Trim(attrs);
            if (0 >= attrs.Count)
            {
                throw new RuntimeException(GetName(), "run function", label, "params count is 0");
            }

            foreach (var attr in attrs)
            {
                if (!m_attribute.ContainsKey(attr))
                {
                    throw new RuntimeException(GetName(), "run function", label, "attribute" + attr + "is not found");
                }
            }

        }

        #endregion


        #region  功能相关

        public void run(string key)
        {
            if (m_attribute.ContainsKey(key))
            {
                m_attribute.GetRegister(key)();
            }
            else
            {
                throw new RuntimeException(GetName(), "found function", key, "not exist");
            }
        }







        public object m_param = null;
        public object m_result = null;

        #endregion
    }



}
