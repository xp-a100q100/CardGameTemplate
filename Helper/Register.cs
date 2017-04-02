using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    public class Register<T> : Register<string, T>
    {

    }
    public class Register<U, T>
    {
        #region 状态
        bool m_modify = false;
        public bool Modify
        {
            get
            {
                return m_modify;
            }
            set
            {
                m_modify = value;
            }
        }
        #endregion

        #region register

        Dictionary<U, T> m_register = new Dictionary<U, T>();

        public List<U> Keys(bool isTrim = false)
        {
            List<U> result = new List<U>(m_register.Keys);
            if (isTrim) result = Helper.Trim(result);
            return result;
        }

        public List<T> Values(bool isTrim = false)
        {
            List<T> result = new List<T>(m_register.Values);
            if (isTrim) result = Helper.Trim(result);
            return result;
        }

        public Register<U, T> SetRegisterObj(Dictionary<U, T> val)
        {
            m_register = new Dictionary<U, T>(val);

            Modify = true;

            return this;
        }
        public Dictionary<U, T> GetRegisterObj()
        {
            return new Dictionary<U, T>(m_register);
        }

        public bool ContainsKey(U key)
        {
            return m_register.ContainsKey(key);
        }

        public Register<U, T> AddRegister(U key, T value)
        {
            m_register[key] = value;

            Modify = true;

            return this;
        }
        public T GetRegister(U key)
        {
            if (ContainsKey(key))
            {
                return m_register[key];
            }
            return default(T);
        }
        public Register<U, T> RemoveRegister(U key)
        {
            if (ContainsKey(key))
            {
                m_register.Remove(key);

                Modify = true;
            }
            return this;
        }

        public List<U> FindKeyWithValue(T t)
        {
            return new List<U>(m_register.Where(q => q.Value.Equals(t)).Select(q => q.Key));
        }

        public U FindFirstKeyWithValue(T t)
        {
            var val = FindKeyWithValue(t);
            if (0 >= val.Count)
            {
                return default(U);
            }
            else
            {
                return val[0];
            }
        }


        #endregion




    }
}
