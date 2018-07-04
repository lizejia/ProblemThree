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

        private readonly CalculateMain _symbolMain;
        public RepeatCheck(CalculateMain symbolMain)
        {
            this._symbolMain = symbolMain;
        }        

        public bool Check()
        {
            int y = 0;
            char prov = _symbolMain.Symbol.ElementAt(0);
            for (int i = 1; i < _symbolMain.Symbol.Count; i++)
            {
                if (prov == _symbolMain.Symbol.ElementAt(i) && neverRepeat.Any(c => c == prov))
                    return false;
                if (prov == _symbolMain.Symbol.ElementAt(i) && repeat.Any(c => c == prov))
                    y++;
                if (y >= 3)
                    return false;
                prov = _symbolMain.Symbol.ElementAt(i);
            }

            return true;
        }
    }
}
