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
        private Dictionary<string, decimal> _anonymousSymbolDic;
        public GoodsSymbolMapper()
        {
            _goodsSymbolDic = new Dictionary<string, SymbolValue>();
            _anonymousSymbolDic = new Dictionary<string, decimal>();
        }

        public void AddAnonymous(string name, decimal value)
        {
            _anonymousSymbolDic.Add(name, value);
        }

        public Dictionary<string, decimal> GetAnonymous()
        {
            return _anonymousSymbolDic;
        }

        public void AddGoods(string name, string symbolStr, decimal value)
        {
            _goodsSymbolDic.Add(name, new SymbolValue
            {
                Symbol = Convert.ToChar(symbolStr),
                Value = value
            });
        }

        public Dictionary<string, SymbolValue> GetGoods()
        {
            return _goodsSymbolDic;
        }
    }
}
