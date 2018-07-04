using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class DefineFirst : ICondition
    {
        private readonly MessageMain _messagemain;
        public DefineFirst(MessageMain messageMain)
        {
            this._messagemain = messageMain;
        }        

        public bool GetGoodsSymbol(string message)
        {
            var reg = Regex.Match(message, @"(^\w+) is ([IVXLCDM])$");
            if (reg.Success)
            {
                string symbol = reg.Groups[2].Value;
                _messagemain.GoodsNameSymbol.Add(reg.Groups[1].Value, new SymbolValue
                                                        {
                                                            Symbol = Convert.ToChar(symbol),
                                                            Value = (decimal)Transform.ToRomanNumeral(symbol)
                                                        });
                return true;
            }
            return false;
        }
    }
}
