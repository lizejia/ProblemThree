using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class RuleMain
    {
        private readonly List<IRule> _iruleList;
        private readonly List<SymbolValue> _checkSymbolList;
        private readonly List<char> _symbolList;
        public RuleMain(List<SymbolValue> symbolValueList)
        {
            _symbolList = symbolValueList.Select(s => s.Symbol).ToList();
            this._checkSymbolList = Tool.MapToSymbolValue(_symbolList);
            this._iruleList = new List<IRule> {
                                        new RepeatCheck(this._symbolList),
                                        new SubtractCheck(this._checkSymbolList)
                                     };
        }
        
        public bool Check()
        {            
            return !_iruleList.Exists(f => !f.Check());
        }
    }
}
