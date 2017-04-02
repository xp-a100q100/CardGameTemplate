using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class ParserData
    {
        public string act = "";
        public List<object> param = new List<object>();
    }

    public static class ParserExpression
    {
        static public ParserData Parser(string content, Dictionary<int, List<string>> lvl_inf, Dictionary<string, int> dims)
        {
            List<object> param = new List<object>() { content };
            List<int> level = new List<int>(lvl_inf.Keys);
            foreach (var lvl in level)
            {
                param = Parser(param, lvl_inf[lvl]);
            }
            foreach (var lvl in level)
            {
                param = Update(param, lvl_inf[lvl], dims);
            }
            ParserData dt = null;
            if (1 != param.Count)
            {
                ;
            }
            else
            {
                dt = param[0] as ParserData;
            }
            return dt;
        }



        static List<object> Parser(string content, List<string> lvl_inf)
        {
            if (string.IsNullOrEmpty(content)) return null;
            
            content = content.Trim();

            int bg = 0;
            string func = null;
            int cur = 0;
            List<object> dataList = new List<object>();
            string head = "";
            string back = "";

            ParserData dt = null;

            string strTemp;
            for (int i = 0; i < content.Length; i++ )
            {
                strTemp = content.Substring(i);
                if (null == func)
                {
                    foreach (var it in lvl_inf)
                    {
                        if (string.IsNullOrEmpty(it))
                        {
                            continue;
                        }
                        if (strTemp != Helper.MatchHead(strTemp, it.Substring(0, 1)))
                        {
                            cur++;
                            dt = new ParserData();
                            dt.act = func = it ;

                            head = content.Substring(bg, i - bg);
                            bg = i + 1;
                            break;
                        }
                    }
                }
                else if (cur < func.Length)
                {
                    if (strTemp != Helper.MatchHead(strTemp, func.Substring(cur, 1)))
                    {
                        dt.param.Add(content.Substring(bg, i - bg));
                        bg = i + 1;
                        break;
                    }
                }
            }
            if (bg != content.Length)
            {
                back = content.Substring(bg, content.Length - bg);
            }

            if (!string.IsNullOrEmpty(head))
            {
                if (head == content)
                {
                    dataList.Add(head);
                }
                else
                {
                    dataList.AddRange(Parser(head, lvl_inf));
                }
            }
            if (null != dt)
            {
                dt.param = Parser(dt.param, lvl_inf);
                dataList.Add(dt);
            }
            if (!string.IsNullOrEmpty(back))
            {
                if (back == content)
                {
                    dataList.Add(back);
                }
                else
                {
                    dataList.AddRange(Parser(back, lvl_inf));
                }
            }
            return dataList;
        }


        static List<object> Parser(List<object> content, List<string> lvl_inf)
        {
            if (null == content || 0 >= content.Count) return content;
            List<object> datalist = new List<object>();

            for (int i = 0; i < content.Count; i++ )
            {
                if (null != content[i] as string)
                {
                    var dt = Parser(content[i] as string, lvl_inf);
                    if (0 >= dt.Count)
                    {
                        datalist.Add(content[i]);
                    }
                    else
                    {
                        datalist.AddRange(dt);
                    }
                }
                else if (null != content[i] as ParserData)
                {
                    var dd = content[i] as ParserData;
                    dd.param = Parser(dd.param, lvl_inf);
                    datalist.Add(dd);
                }
                else
                {
                    datalist.Add(content[i]);
                }
            }
            return datalist;
        }

        static List<object> Update(List<object> content, List<string> lvl_inf, Dictionary<string, int> dims)
        {
            if (null == content || 0 >= content.Count) return content;
            List<object> datalist = new List<object>();

            for (int i = 0; i < content.Count; i++)
            {
                if (null != content[i] as string)
                {
                    datalist.Add(content[i]);
                }
                else if (null != content[i] as ParserData)
                {
                    var dd = content[i] as ParserData;
                    dd.param = Update(dd.param, lvl_inf, dims);

                    if (null == dd.act)
                    {
                        ;
                    }
                    int n = dims[dd.act];
                    if (!lvl_inf.Contains(dd.act) || 0 == n)
                    {
                        ;
                    }
                    else if (1 == n)
                    {
                        if (dd.param.Count >= n)
                        {
                            ;
                        }
                        else if (i + 1 >= content.Count)
                        {
                            ;
                        }
                        else 
                        {
                            dd.param.Add(content[++i]);
                        }
                    }
                    else if (2 <= n)
                    {
                        if (dd.param.Count >= n || i - 1 < 0)
                        {
                            ;
                        }
                        else if (dd.param.Count + 1 < n)
                        {
                            dd.param.Add(datalist.Last());
                            datalist.RemoveAt(datalist.Count - 1);
                        }

                        if (dd.param.Count >= n || i + 1 >= content.Count)
                        {
                            ;
                        }
                        else
                        {
                            ParserData bb = content[++i] as ParserData;
                            if (null != bb)
                            {
                                bb.param = Update(bb.param, lvl_inf, dims);
                                dd.param.Add(bb);
                            }
                            else
                            {
                                dd.param.Add(content[i]);
                            }
                        }
                    }
                    datalist.Add(dd);
                }
                else
                {
                    datalist.Add(content[i]);
                }
            }
            return datalist;
        }



        static public void Test()
        {
            Dictionary<int, List<string>> levelInfo = new Dictionary<int, List<string>>();
            Dictionary<string, int> m_dims = new Dictionary<string, int>();


            string content = "a * b + m * ( a + b) + c * d + a";
            levelInfo.Add(1, new List<string>()
                {
                    "()",
                });
            levelInfo.Add(2, new List<string>()
                {
                    "*",
                });
            levelInfo.Add(3, new List<string>()
                {
                    "+",
                });
            m_dims.Add("()", 1);
            m_dims.Add("*", 2);
            m_dims.Add("+", 2);


            ParserData dt = Parser(content, levelInfo, m_dims);

           
        }



    }


}
