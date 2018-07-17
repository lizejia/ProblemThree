using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class SubtractCheck : IRule
    {
        private readonly List<string> _subtractList = new List<string> { "IV", "IX", "XL", "XC", "CD", "CM" };
        private readonly List<SymbolValue> _checkSymbolList;
        
        public SubtractCheck(string romanStr)
        {
            _checkSymbolList = Tool.MapToSymbolValue(romanStr);
        }
        public bool Check()
        {
            for (int i = 0; i < _checkSymbolList.Count - 1; i++)
            {
                if (_checkSymbolList[i].Value < _checkSymbolList[i + 1].Value)
                {
                    string symbolSubtractStr = _checkSymbolList[i].Symbol.ToString() + _checkSymbolList[i + 1].Symbol.ToString();
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
