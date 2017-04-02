using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class CardOperator : RuleOperator
    {
        new public const string Name = "Card";
        
        #region 实现父类继承
        public CardOperator(string name = AttributeOperator.Name)
            : base(name)
        {

        }
        
        protected override void  init()
        {
        }

        
        public static List<Card> multiply(List<List<Card>> a)
        {
            if (0 >= a.Count) return new List<Card>();
            else if (1 == a.Count) return new List<Card>(a[0]);
            else if (2 == a.Count) return multiply(a[0], a[1]);
            else return multiply(a[0], multiply(a.GetRange(1, a.Count - 1)));
        }

        public static List<Card> multiply(List<Card> a, List<Card> b)
        {
            List<Card> result = new List<Card>();

            foreach (var ita in a)
            {
                foreach (var itb in b)
                {
                    Card c = new Card();

                    foreach (var it in ita.Keys())
                    {
                        c.AddRegister(it, ita.GetRegister(it));
                    }
                    foreach (var it in itb.Keys())
                    {
                        c.AddRegister(it, itb.GetRegister(it));
                    }
                    result.Add(c);
                }
            }
            return result;
        }


        #endregion

    }




}
