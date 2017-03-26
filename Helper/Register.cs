﻿using System;
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

        #region register

        Dictionary<U, T> m_register = new Dictionary<U, T>();

        public void SetRegisterObj(Dictionary<U, T> val)
        {
            m_register = new Dictionary<U, T>(val);
        }
        public Dictionary<U, T> GetRegisterObj()
        {
            return new Dictionary<U, T>(m_register);
        }

        public bool ContainsKey(U key)
        {
            return m_register.ContainsKey(key);
        }

        public void AddRegister(U key, T value)
        {
            m_register[key] = value;
        }
        public T GetRegister(U key)
        {
            if (ContainsKey(key))
            {
                return m_register[key];
            }
            return default(T);
        }
        public void RemoveRegister(U key)
        {
            if (ContainsKey(key))
            {
                m_register.Remove(key);
            }
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
