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
        public static List<string> Trim(List<string> content)
        {
            return new List<string>(content.Where((x, i) => content.FindIndex(z => z == x) == i));
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


    }
}
