using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class CalculateMain
    {
        private List<char> _symbol;
        private List<SymbolValue> _symbolValues;
        private List<IRule> _irule;

        public CalculateMain(List<SymbolValue> symbolValues)
        {
            this._symbolValues = symbolValues;
            this._symbol = symbolValues.Select(s => s.Symbol).ToList();
            _irule = new List<IRule> {
                                        new RepeatCheck(this),
                                        new SubtractCheck(this)
                                     };
        }
        public List<char> Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }


        public bool Check()
        {            
            return !_irule.Exists(f => !f.Check());
        }

        public decimal Calculate()
        {
            decimal total = 0M;
            for (int i = 0; i < _symbolValues.Count; i++)
            {
                int nextIndex = i + 1;
                if (nextIndex < _symbolValues.Count && _symbolValues[i].Value < _symbolValues[nextIndex].Value)
                {
                    total += _symbolValues[i + 1].Value - _symbolValues[i].Value;
                    i++;
                }
                else
                {
                    if (_symbolValues[i].Symbol != ' ')
                    {
                        total += _symbolValues[i].Value;
                    }
                    else
                    {
                        total = total * _symbolValues[i].Value;
                    }
                }
            }
            return total;
        }
    }
}
