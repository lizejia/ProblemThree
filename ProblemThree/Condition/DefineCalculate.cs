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
        private readonly GoodsSymbolMapper _goodsNameSymbol;
        public DefineCalculate(GoodsSymbolMapper goodsNameSymbol)
        {
            this._goodsNameSymbol = goodsNameSymbol;
        }
        public bool GetSymbolValuesByMessage(string message)
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
                    if (_goodsNameSymbol.GetGoods().Any(a => a.Key == metalCollection[i].Value))
                    {
                        symbolValues.Add(_goodsNameSymbol.GetGoods()[metalCollection[i].Value]);
                    }
                    else
                    {
                        calculateGoods = metalCollection[i].Value;
                    }                    
                }
                RuleMain sm = new RuleMain(symbolValues);
                if (sm.Check())
                {
                    CalculateMain calculateMain = new CalculateMain(new NormalRomanCalculate(symbolValues));
                    var total = calculateMain.ExecuteStrategy(1);
                    var price = decimal.Parse(reg.Groups[2].Value) / total;
                    _goodsNameSymbol.AddAnonymous(calculateGoods, price);//U代表未知
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
