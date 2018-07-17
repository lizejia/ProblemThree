using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public abstract class CalculateStrategy
    {
        private readonly List<SymbolValue> _calculateSymbolList;
        private readonly decimal normalPrice;
        public CalculateStrategy(string romanStr)
        {
            this._calculateSymbolList = Tool.MapToSymbolValue(romanStr);
            this.normalPrice = NormalCalculate();
        }
        public abstract decimal CalculatePrice();

        private decimal NormalCalculate()
        {
            decimal total = 0M;
            for (int i = 0; i < this._calculateSymbolList.Count; i++)
            {
                int nextIndex = i + 1;
                if (nextIndex < this._calculateSymbolList.Count && this._calculateSymbolList[i].Value < this._calculateSymbolList[nextIndex].Value)
                {
                    total += this._calculateSymbolList[i + 1].Value - this._calculateSymbolList[i].Value;
                    i++;
                }
                else
                {
                    total += _calculateSymbolList[i].Value;
                }
            }
            return total;
        }
        
        public decimal GetNormalPrice()
        {
            return normalPrice;
        }
    }
}
