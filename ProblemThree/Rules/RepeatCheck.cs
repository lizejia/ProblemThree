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
        private readonly List<char> _checkSymbol;

        public RepeatCheck(List<char> checkSymbol)
        {
            this._checkSymbol = checkSymbol;
        }        

        public bool Check()
        {
            int y = 0;
            char prov = _checkSymbol.ElementAt(0);
            for (int i = 1; i < _checkSymbol.Count; i++)
            {
                if (prov == _checkSymbol.ElementAt(i) && neverRepeat.Any(c => c == prov))
                    return false;
                if (prov == _checkSymbol.ElementAt(i) && repeat.Any(c => c == prov))
                    y++;
                if (y >= 3)
                    return false;
                prov = _checkSymbol.ElementAt(i);
            }

            return true;
        }
    }
}
