using ProblemThree.Model;
using ProblemThree.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class GalaxyCalculate
    {
        public List<string> GalaxyNumber { get; set; }
        public Dictionary<string, RomanNumbers> GalaxyNumberMapper { get; set; }
        public decimal GalaxyNumberPrice { get; set; } = 0M;

        public string Unit { get; set; }

        public decimal CreditsPrice { get; set; }

        public Dictionary<string, decimal> GalaxyUnitMapper { get; set; }

        public GalaxyCalculate()
        {
            GalaxyNumber = new List<string>();
            GalaxyNumberMapper = new Dictionary<string, RomanNumbers>();
            GalaxyUnitMapper = new Dictionary<string, decimal>();
        }

        public void Calculate()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in GalaxyNumber)
            {
                stringBuilder.Append(GalaxyNumberMapper[item].ToString());
            }
            string romanStr = stringBuilder.ToString();
            RuleMain ruleMain = new RuleMain(romanStr);
            if (ruleMain.Check())
            {
                var _calculateSymbolList = romanStr.ToList();
                for (int i = 0; i < _calculateSymbolList.Count; i++)
                {
                    int nextIndex = i + 1;
                    var currentPrice = (decimal)Tool.ToRomanNumeral(_calculateSymbolList[i].ToString());
                    var nextPrice = nextIndex < _calculateSymbolList.Count ? (decimal)Tool.ToRomanNumeral(_calculateSymbolList[nextIndex].ToString()) : 0M;
                    if (currentPrice < nextPrice)
                    {
                        GalaxyNumberPrice += nextPrice - currentPrice;
                        i++;
                    }
                    else
                    {
                        GalaxyNumberPrice += currentPrice;
                    }
                }
                if (string.IsNullOrEmpty(Unit))
                    return;
                //GalaxyUnitMapper[Unit] * GalaxyNumberPrice = CreditsPrice;
                if (!GalaxyUnitMapper.Any())
                {
                    GalaxyUnitMapper.Add(Unit, CreditsPrice / GalaxyNumberPrice);
                }
                else
                {
                    CreditsPrice = GalaxyUnitMapper[Unit] * GalaxyNumberPrice;
                }
            }
        }
    }
}
