using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class CheckCalculate
    {
        private readonly List<SymbolValue> _calculateSymbolList;
        private readonly List<IRule> _iruleList;
        private readonly List<SymbolValue> _checkSymbolList;
        private readonly List<char> _symbolList;
        
        public CheckCalculate(List<SymbolValue> symbolValueList)
        {
            _symbolList = symbolValueList.Select(s => s.Symbol).ToList();
            this._checkSymbolList = Tool.MapToSymbolValue(_symbolList);
            this._iruleList = new List<IRule> {
                                        new RepeatCheck(this._symbolList),
                                        new SubtractCheck(this._checkSymbolList)
                                     };
            this._calculateSymbolList = symbolValueList;
        }
        
        public bool Check()
        {            
            return !_iruleList.Exists(f => !f.Check());
        }

        public decimal CalculatePrice()
        {
            decimal total = 0M;
            for (int i = 0; i < _calculateSymbolList.Count; i++)
            {
                int nextIndex = i + 1;
                if (nextIndex < _calculateSymbolList.Count && _calculateSymbolList[i].Value < _calculateSymbolList[nextIndex].Value)
                {
                    total += _calculateSymbolList[i + 1].Value - _calculateSymbolList[i].Value;
                    i++;
                }
                else
                {
                    if (_calculateSymbolList[i].Symbol != 'U')
                    {
                        total += _calculateSymbolList[i].Value;
                    }
                    else
                    {
                        total = total * _calculateSymbolList[i].Value;
                    }
                }
            }
            return total;
        }
    }
}
