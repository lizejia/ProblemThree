using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class Calculate
    {
        private List<char> _symbolList;
        private List<SymbolValue> _calculateSymbols;
        private List<IRule> _irule;
        private readonly List<SymbolValue> _checkSymbol;

        public List<char> SymbolList
        {
            get { return _symbolList; }
            set { _symbolList = value; }
        }

        public Calculate(List<SymbolValue> symbolValues)
        {
            this._calculateSymbols = symbolValues;
            this._symbolList = symbolValues.Select(s => s.Symbol).ToList();
            Init();
            _irule = new List<IRule> {
                                        new RepeatCheck(this),
                                        new SubtractCheck(this._checkSymbol)
                                     };
        }

        public Calculate(string symbolsStr)
        {
            this._symbolList = symbolsStr.ToList();
            Init();
            this._calculateSymbols = this._checkSymbol;
            _irule = new List<IRule> {
                                        new RepeatCheck(this),
                                        new SubtractCheck(this._checkSymbol)
                                     };
        }       

        private void Init()
        {
            foreach (var item in this._symbolList)
            {
                var provStr = item.ToString().Trim();
                this._calculateSymbols.Add(new SymbolValue() { Symbol = item, Value = (decimal)Transform.ToRomanNumeral(provStr) });
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
