using ProblemThree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree.Calculate
{
    public abstract class CalculateStrategy
    {
        public List<string> GalaxyNumber { get; set; }
        public Dictionary<string, RomanNumbers> GalaxyNumberMapper { get; set; }
        public decimal GalaxyNumberPrice { get; set; } = 0M;

        public CalculateStrategy()
        {
            GalaxyNumber = new List<string>();
            GalaxyNumberMapper = new Dictionary<string, RomanNumbers>();
        }
        public abstract void Calculate();

        public void NumberCalculate()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in GalaxyNumber)
            {
                stringBuilder.Append(GalaxyNumberMapper[item].ToString());
            }
            string romanStr = stringBuilder.ToString();

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
        }        
    }
}
