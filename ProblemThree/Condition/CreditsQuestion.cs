using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class CreditsQuestion : ICondition
    {
        private readonly GoodsSymbolMapper _goodsNameSymbol;
        private readonly List<string> _outputList;
        public CreditsQuestion(GoodsSymbolMapper goodsNameSymbol, List<string> outputList)
        {
            this._goodsNameSymbol = goodsNameSymbol;
            this._outputList = outputList;
        }
        public bool GetSymbolValuesByMessage(string message)
        {
            var reg = Regex.Match(message, @"^how many Credits is ([\w+\s]+) [\\?]$");
            if (reg.Success)
            {
                var metals = reg.Groups[1].Value;
                var metalCollection = Regex.Matches(metals, @"(\w+)");
                List<SymbolValue> symbolValues = new List<SymbolValue>();
                decimal creditsPrice = 1M;
                for (int i = 0; i < metalCollection.Count; i++)
                {
                    if (_goodsNameSymbol.GetGoods().Any(a => a.Key == metalCollection[i].Value))
                    {
                        symbolValues.Add(_goodsNameSymbol.GetGoods()[metalCollection[i].Value]);
                    }
                    else
                    {
                        creditsPrice = _goodsNameSymbol.GetAnonymous()[metalCollection[i].Value];
                    }
                }
                RuleMain sm = new RuleMain(symbolValues);
                if (sm.Check())
                {
                    CalculateMain calculateMain = new CalculateMain(new CreditsCalculate(symbolValues));
                    var total = calculateMain.ExecuteStrategy(creditsPrice);
                    this._outputList.Add($"{metals} is {total.ToString("#.##")} Credits");
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
