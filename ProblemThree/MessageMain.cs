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
        public CheckCalculate checkCalculate;
        private readonly List<ICondition> _icondition;
        private readonly List<string> outputs;
        public MessageMain()
        {
            GoodsNameSymbol = new Dictionary<string, SymbolValue>();
            _icondition = new List<ICondition> {
                                        new DefineFirst(this),
                                        new DefineCalculate(this),
                                        new MuchQuestion(this),
                                        new CreditsQuestion(this)
                                     };
            outputs = new List<string>();
        }

        public void AddOutputs(string message)
        {
            outputs.Add(message);
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
                if (!_icondition.Exists(e => e.GetSymbolValuesByMessage(message)))
                {
                    outputs.Add("I have no idea what you are talking about");
                }
            }
            return string.Join("\r\n", outputs);
        }
    }
}
