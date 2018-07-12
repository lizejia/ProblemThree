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
        private readonly GoodsSymbolMapper _goodsNameSymbol;
        public DefineFirst(GoodsSymbolMapper goodsNameSymbol)
        {
            this._goodsNameSymbol = goodsNameSymbol;
        }        

        public bool GetSymbolValuesByMessage(string message)
        {
            var reg = Regex.Match(message, @"(^\w+) is ([IVXLCDM])$");
            if (reg.Success)
            {
                string symbol = reg.Groups[2].Value;
                //添加直接定义值
                _goodsNameSymbol.AddGoods(reg.Groups[1].Value, symbol, (decimal)Tool.ToRomanNumeral(symbol));
                return true;
            }
            return false;
        }
    }
}
