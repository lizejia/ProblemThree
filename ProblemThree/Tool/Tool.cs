using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class Tool
    {
        public static RomanNumerals ToRomanNumeral(string goodsName)
        {
            RomanNumerals res;
            Enum.TryParse(goodsName, out res);
            return res;
        }

        public static List<SymbolValue> MapToSymbolValue(string symbolStr)
        {
            var symbolValues = new List<SymbolValue>();
            foreach (var item in symbolStr.ToList())
            {
                var provStr = item.ToString();
                symbolValues.Add(new SymbolValue() { Symbol = item, Value = (decimal)ToRomanNumeral(provStr) });
            }
            return symbolValues;
        }

        public static List<SymbolValue> MapToSymbolValue(List<char> symbols)
        {
            var symbolValues = new List<SymbolValue>();
            foreach (var item in symbols)
            {
                var provStr = item.ToString();
                symbolValues.Add(new SymbolValue() { Symbol = item, Value = (decimal)ToRomanNumeral(provStr) });
            }
            return symbolValues;
        }
    }
}
