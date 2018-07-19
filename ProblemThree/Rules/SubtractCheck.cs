using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree.Rules
{
    public class SubtractCheck : IRule
    {
        private readonly List<string> _subtractList = new List<string> { "IV", "IX", "XL", "XC", "CD", "CM" };
        private readonly List<char> _checkSymbolList;
        public SubtractCheck(string romanStr)
        {
            _checkSymbolList = romanStr.ToList();
        }
        public bool Check()
        {
            for (int i = 0; i < _checkSymbolList.Count - 1; i++)
            {
                string current = _checkSymbolList[i].ToString();
                string next = _checkSymbolList[i + 1].ToString();
                if ((decimal)Tool.ToRomanNumeral(current) < (decimal)Tool.ToRomanNumeral(next))
                {
                    string symbolSubtractStr = current + next;
                    if (!_subtractList.Any(a => a == symbolSubtractStr))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
    }
}
