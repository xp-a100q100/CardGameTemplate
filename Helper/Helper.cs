using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public static class Helper
    {
        public static List<T> Trim<T>(List<T> content)
        {
            return new List<T>(content.Where((x, i) => content.FindIndex(z => z.Equals(x)) == i));
        }



        #region  反射创建类型

        public static object Create(string name)
        {
            try
            {
                Type tp = Type.GetType(name);
                return Create(tp);
            }
            catch
            {
                return null;
            }
        }
        public static object Create(Type tp)
        {
            try
            {
                ConstructorInfo ct = tp.GetConstructor(System.Type.EmptyTypes);
                return ct.Invoke(null);
            }
            catch
            {
                return null;
            }
        }

        #endregion



        #region 表达式字符串解析

        public static string MatchHead(string content, string pattern)
        {
            if (content.Length >= pattern.Length
                && content.Substring(0, pattern.Length) == pattern)
            {
                return content.Substring(pattern.Length);
            }
            return content;
        }

        #endregion


    
    }
}
