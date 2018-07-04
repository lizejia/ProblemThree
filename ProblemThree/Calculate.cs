using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class Calculate
    {
        private readonly List<SymbolValue> _calculateSymbols;
        private readonly List<IRule> _irule;
        private readonly List<SymbolValue> _checkSymbol;
        private readonly List<char> _symbolList;

        public Calculate(string symbolsStr)
        {
            _symbolList = symbolsStr.ToList();
            this._checkSymbol = new List<SymbolValue>();
            Init();
            this._irule = new List<IRule> {
                                        new RepeatCheck(this._symbolList),
                                        new SubtractCheck(this._checkSymbol)
                                     };
            this._calculateSymbols = this._checkSymbol;
        }

        public Calculate(List<SymbolValue> symbolValues)
        {
            _symbolList = symbolValues.Select(s => s.Symbol).ToList();
            this._checkSymbol = new List<SymbolValue>();
            Init();
            this._irule = new List<IRule> {
                                        new RepeatCheck(this._symbolList),
                                        new SubtractCheck(this._checkSymbol)
                                     };
            this._calculateSymbols = symbolValues;
        }

        private void Init()
        {
            foreach (var item in this._symbolList)
            {
                var provStr = item.ToString().Trim();
                this._checkSymbol.Add(new SymbolValue() { Symbol = item, Value = (decimal)Transform.ToRomanNumeral(provStr) });
            }
        }


        public bool Check()
        {            
            return !_irule.Exists(f => !f.Check());
        }

        public decimal CalculatePrice()
        {
            decimal total = 0M;
            for (int i = 0; i < _calculateSymbols.Count; i++)
            {
                int nextIndex = i + 1;
                if (nextIndex < _calculateSymbols.Count && _calculateSymbols[i].Value < _calculateSymbols[nextIndex].Value)
                {
                    total += _calculateSymbols[i + 1].Value - _calculateSymbols[i].Value;
                    i++;
                }
                else
                {
                    if (_calculateSymbols[i].Symbol != ' ')
                    {
                        total += _calculateSymbols[i].Value;
                    }
                    else
                    {
                        total = total * _calculateSymbols[i].Value;
                    }
                }
            }
            return total;
        }
    }
}
