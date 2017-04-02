using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class RuleOperator : Register<OperatorBase>
    {
        public const string Name = "RuleOperator";
        string m_name = "";
        
        #region  构造和初始化
        public RuleOperator(string name = RuleOperator.Name)
        {
            m_name = name;

            init();
        }
        public string GetName()
        {
            return this.m_name;
        }


        #endregion

        #region  子類需要實現函數

        protected virtual void init() 
        {

        }

        #endregion

        #region 注册信息相关

        Register<OperatorBase, int> m_level = new Register<OperatorBase, int>();

        public void AddRegister(string key, OperatorBase act, int level)
        {
            AddRegister(key, act);
            SetLevel(act, level);
        }
        public void SetLevel(OperatorBase act, int level)
        {
            m_level.AddRegister(act, level);
        }
        public int GetLevel(string key)
        {
            OperatorBase act = GetRegister(key);
            if (act == default(OperatorBase))
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

        public Dictionary<int, List<OperatorBase>> GetLevel()
        {
            Dictionary<int, List<OperatorBase>> dt = new Dictionary<int, List<OperatorBase>>();
            var keys = m_level.Values(true);
            foreach (var it in keys)
            {
                if (!dt.ContainsKey(it))
                {
                    dt.Add(it, new List<OperatorBase>());
                }

                dt[it] = m_level.FindKeyWithValue(it);
            }
            return dt;
        }


        #endregion


        #region 参数检查
        public void checkParam(List<string> attrs, OperatorBase act)
        {
            string label = "";
            if (string.IsNullOrEmpty(FindFirstKeyWithValue(act)))
            {
                throw new RegisterException(GetName(), "no register function", act.GetName(), "");
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
                if (!ContainsKey(attr))
                {
                    throw new RuntimeException(GetName(), "run function", label, "attribute" + attr + "is not found");
                }
            }

        }

        #endregion


        #region  功能相关

        public virtual ParserData Parser(List<string> content)
        {
            return null;
        }

        public virtual ParserData Parser(string content)
        {
            Dictionary<int, List<OperatorBase>> lvl_inf = GetLevel();
            Dictionary<int, List<string>> lvl;
            Dictionary<string, int> dims;
            CheckParserLevel(lvl_inf, out lvl, out dims);
            return ParserExpression.Parser(content, lvl, dims);
        }

        void CheckParserLevel(Dictionary<int, List<OperatorBase>> lvl_inf,
            out Dictionary<int, List<string>> lvl,
            out Dictionary<string, int> dims)
        {
            lvl = new Dictionary<int,List<string>>();
            dims = new Dictionary<string,int>();


            List<string> strList = new List<string>();
            string strTemp = "";
            foreach ( var it in lvl_inf)
            {
                strList = new List<string>();
                foreach ( var nd in it.Value)
                {
                    strTemp = FindFirstKeyWithValue(nd);
                    if (!string.IsNullOrEmpty(strTemp))
                    {
                        strList.Add(strTemp);
                        dims.Add(strTemp, nd.Dim);
                    }
                }
                lvl.Add(it.Key, strList);
            }
        }




        #endregion


        #region 基本功能
        public object run(string key, object param)
        {
            object result = null;
            if (ContainsKey(key))
            {
                result = GetRegister(key).run(param);
            }
            else
            {
                throw new RuntimeException(GetName(), "found function", key, "not exist");
            }
            return result;
        }

        public object runParser(ParserData param)
        {
            object result = null;
            string key = param.act;
            if (ContainsKey(key))
            {
                for( int i = 0; i < param.param.Count; i++)
                {
                    if (typeof(ParserData) == param.param[i].GetType())
                    {
                        param.param[i] = runParser(param.param[i] as ParserData);
                    }
                }
                result = GetRegister(key).run(param.param);
            }
            else
            {
                throw new RuntimeException(GetName(), "found function", key, "not exist");
            }
            return result;
        }


        #endregion
    }



}
