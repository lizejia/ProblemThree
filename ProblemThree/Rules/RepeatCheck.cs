using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree.Rules
{
    public class RepeatCheck : IRule
    {
        private readonly List<char> neverRepeatList = new List<char> { 'D', 'L', 'V' };
        private readonly List<char> repeatList = new List<char> { 'I', 'X', 'C', 'M' };
        private readonly List<char> _checkSymbolList;

        public RepeatCheck(string romanStr)
        {
            this._checkSymbolList = romanStr.ToList();
        }        

        public bool Check()
        {
            int repeatTime = 0;
            char current = _checkSymbolList.ElementAt(0);
            for (int i = 1; i < _checkSymbolList.Count; i++)
            {
                var next = _checkSymbolList.ElementAt(i);
                if (current != next)
                    repeatTime = 0;
                if (neverRepeatList.Any(c => c == current) && current == next)
                    return false;                
                if (repeatList.Any(c => c == current) && current == next)
                    repeatTime++;
                if (repeatTime > 3)
                    return false;
                current = next;
            }
            return true;
        }
    }
}
