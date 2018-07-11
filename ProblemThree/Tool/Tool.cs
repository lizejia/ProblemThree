using System;
using System.Collections.Generic;
using System.IO;
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

        public static string ReadTxtContent(string path)
        {
            path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + path;
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                StreamReader streamReader = new StreamReader(fileStream);
                string result = streamReader.ReadToEnd();
                streamReader.Close();
                return result;
            }
        }

        public static void WirteOutput(string output)
        {
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "output.txt";
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLineAsync(output);
                streamWriter.Close();
            }
        }
    }
}
