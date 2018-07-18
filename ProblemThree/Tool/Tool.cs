using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class Tool
    {
        public static RomanNumbers ToRomanNumeral(string goodsName)
        {
            Enum.TryParse(goodsName, out RomanNumbers res);
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
        
        public static string ReadTxtContent()
        {
            string path = ConfigurationManager.AppSettings["InputPath"];
            string result = "";
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                StreamReader streamReader = new StreamReader(fileStream);
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}
