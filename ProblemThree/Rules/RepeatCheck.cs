using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class RepeatCheck : IRule
    {
        private readonly List<char> neverRepeat = new List<char> { 'D', 'L', 'V' };
        private readonly List<char> repeat = new List<char> { 'I', 'X', 'C', 'M' };

        private readonly Calculate _calculate;

        public RepeatCheck(Calculate calculate)
        {
            this._calculate = calculate;
        }        

        public bool Check()
        {
            int y = 0;
            char prov = _calculate.SymbolList.ElementAt(0);
            for (int i = 1; i < _calculate.SymbolList.Count; i++)
            {
                if (prov == _calculate.SymbolList.ElementAt(i) && neverRepeat.Any(c => c == prov))
                    return false;
                if (prov == _calculate.SymbolList.ElementAt(i) && repeat.Any(c => c == prov))
                    y++;
                if (y >= 3)
                    return false;
                prov = _calculate.SymbolList.ElementAt(i);
            }

            return true;
        }
    }
}
