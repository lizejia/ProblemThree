using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class SubtractCheck : IRule
    {
        private readonly List<string> _subtract = new List<string> { "IV", "IX", "XL", "XC", "CD", "CM" };
        private readonly List<SymbolValue> _checkSymbol;
        private readonly Calculate _calculate;
        
        public SubtractCheck(List<SymbolValue> checkSymbol)
        {
            _checkSymbol = checkSymbol;
        }
        public bool Check()
        {
            for (int i = 0; i < _checkSymbol.Count - 1; i++)
            {
                if (_checkSymbol[i].Value < _checkSymbol[i + 1].Value)
                {
                    string symbolSubtractStr = _checkSymbol[i].Symbol.ToString() + _checkSymbol[i + 1].Symbol.ToString();
                    if (!_subtract.Any(a => a == symbolSubtractStr))
                    {
                        return false;
                    }
                }
            }
            return true;
        }        
    }
}
