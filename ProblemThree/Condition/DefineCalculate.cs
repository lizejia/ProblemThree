using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class DefineCalculate : ICondition
    {
        private readonly MessageMain _messagemain;
        public DefineCalculate(MessageMain messageMain)
        {
            this._messagemain = messageMain;
        }
        public bool GetGoodsSymbol(string message)
        {
            var reg = Regex.Match(message, @"([\w+\s]+) is (\d+) Credits");            
            if (reg.Success)
            {                
                var metals = reg.Groups[1].Value;
                var metalCollection = Regex.Matches(metals, @"(\w+)");
                List<SymbolValue> symbolValues = new List<SymbolValue>();
                string calculateGoods = "";
                for (int i = 0; i < metalCollection.Count; i++)
                {
                    if (_messagemain.GoodsNameSymbol.Any(a => a.Key == metalCollection[i].Value))
                    {
                        symbolValues.Add(_messagemain.GoodsNameSymbol[metalCollection[i].Value]);
                    }
                    else
                    {
                        calculateGoods = metalCollection[i].Value;
                    }                    
                }
                CalculateMain sm = new CalculateMain(symbolValues);
                if (sm.Check())
                {
                    var total = sm.Calculate();
                    var price = decimal.Parse(reg.Groups[2].Value) / total;
                    _messagemain.GoodsNameSymbol.Add(calculateGoods, new SymbolValue() { Symbol = ' ', Value = price });
                }
                return true;
            }
            return false;
        }
    }
}
