using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class SubtractCheck : IRule
    {
        protected readonly List<string> subtract = new List<string> { "IV", "IX", "XL", "XC", "CD", "CM" };
        protected readonly List<SymbolValue> SymbolValues;
        private readonly Calculate _symbolMain;
        
        public SubtractCheck(Calculate symbolMain)
        {
            this._symbolMain = symbolMain;
            SymbolValues = new List<SymbolValue>();
            Init();
        }
        private void Init()
        {
            foreach (var item in _symbolMain.Symbol)
            {
                var provStr = item.ToString().Trim();
                SymbolValues.Add(new SymbolValue() { Symbol = item, Value = (decimal)Transform.ToRomanNumeral(provStr) });
            }
        }
        public bool Check()
        {
            for (int i = 0; i < SymbolValues.Count - 1; i++)
            {
                if (SymbolValues[i].Value < SymbolValues[i + 1].Value)
                {
                    string symbolSubtractStr = SymbolValues[i].Symbol.ToString() + SymbolValues[i + 1].Symbol.ToString();
                    if (!subtract.Any(a => a == symbolSubtractStr))
                    {
                        return false;
                    }
                }
            }
            return true;
        }        
    }
}
