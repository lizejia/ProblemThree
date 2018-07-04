using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class MuchQuestion : ICondition
    {
        private readonly MessageMain _messagemain;
        public MuchQuestion(MessageMain messagemain)
        {
            this._messagemain = messagemain;
        }
        public bool GetGoodsSymbol(string message)
        {
            var reg = Regex.Match(message, @"^how much is ([\w+\s]+) [\\?]$");
            if (reg.Success)
            {
                var metals = reg.Groups[1].Value;
                var metalCollection = Regex.Matches(metals, @"(\w+)");
                List<SymbolValue> symbolValues = new List<SymbolValue>();
                for (int i = 0; i < metalCollection.Count; i++)
                {
                    symbolValues.Add(_messagemain.GoodsNameSymbol[metalCollection[i].Value]);
                }
                Calculate sm = new Calculate(symbolValues);
                if (sm.Check())
                {
                    var total = sm.CalculatePrice();
                    _messagemain.AddOutputs($"{metals} is {total}");
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
