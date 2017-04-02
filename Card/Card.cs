using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card : Register<string>
    {
        #region 构造函数
        public Card()
        {

        }
        public Card(Card that)
        {
            SetRegisterObj(that.GetRegisterObj());
        }
        public Card(Dictionary<string, string> attrs)
        {
            SetRegisterObj(attrs);
        }
        #endregion




    }
}
