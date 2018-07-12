using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class SymbolValue
    {
        public char Symbol { get; set; }
        public decimal Value { get; set; }
    }

    public class GoodsSymbolMapper
    {
        private Dictionary<string, SymbolValue> _goodsSymbolDic;
        public GoodsSymbolMapper()
        {
            _goodsSymbolDic = new Dictionary<string, SymbolValue>();
        }

        public void Add(string name, string symbolStr, decimal value)
        {
            _goodsSymbolDic.Add(name, new SymbolValue
            {
                Symbol = Convert.ToChar(symbolStr),
                Value = value
            });
        }

        public Dictionary<string, SymbolValue> Get()
        {
            return _goodsSymbolDic;
        }
    }
}
