using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class MessageMain
    {
        public Dictionary<string, SymbolValue> GoodsNameSymbol { get; set; }
        private readonly List<ICondition> _iconditionList;
        private readonly List<string> _outputList;
        public MessageMain()
        {
            GoodsNameSymbol = new Dictionary<string, SymbolValue>();
            _iconditionList = new List<ICondition> {
                                        new DefineFirst(this),
                                        new DefineCalculate(this),
                                        new MuchQuestion(this),
                                        new CreditsQuestion(this)
                                     };
            _outputList = new List<string>();
        }

        public void AddOutputs(string message)
        {
            _outputList.Add(message);
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
