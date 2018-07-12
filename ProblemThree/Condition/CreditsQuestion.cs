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
                for (int i = 0; i < metalCollection.Count; i++)
                {
                    symbolValues.Add(_goodsNameSymbol.Get()[metalCollection[i].Value]);
                }
                CheckCalculate sm = new CheckCalculate(symbolValues);
                if (sm.Check())
                {
                    var total = sm.CalculatePrice();
                    this._outputList.Add($"{metals} is {total.ToString("#.##")} Credits");
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
