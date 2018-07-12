using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class MessageMain
    {
        public GoodsSymbolMapper _goodsNameSymbol;
        private readonly List<ICondition> _iconditionList;
        private readonly List<string> _outputList;
        public MessageMain()
        {
            _goodsNameSymbol = new GoodsSymbolMapper();
            _outputList = new List<string>();
            _iconditionList = new List<ICondition> {
                                        new DefineFirst(_goodsNameSymbol),
                                        new DefineCalculate(_goodsNameSymbol),
                                        new MuchQuestion(_goodsNameSymbol,_outputList),
                                        new CreditsQuestion(_goodsNameSymbol,_outputList)
                                     };
        }

        public string Start(string input)
        {
            var messages = input.Split(new[] { '\r', '\n' });
            foreach (var message in messages)
            {
                if (string.IsNullOrEmpty(message))
                {
                    continue;
                }
                if (!_iconditionList.Exists(e => e.GetSymbolValuesByMessage(message)))
                {
                    _outputList.Add("I have no idea what you are talking about");
                }
            }
            return string.Join("\r\n", _outputList);
        }
    }
}
