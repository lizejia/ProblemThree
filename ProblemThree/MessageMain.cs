using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class MessageMain
    {
        private Dictionary<string, SymbolValue> _goodsnamesymbol;
        public Dictionary<string, SymbolValue> GoodsNameSymbol
        {
            get { return _goodsnamesymbol; }
            set { _goodsnamesymbol = value; }
        }

        private readonly List<ICondition> _icondition;
        private readonly List<string> outputs;
        public MessageMain()
        {
            _goodsnamesymbol = new Dictionary<string, SymbolValue>();
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

        public void GetGoodsSymbol(string input)
        {
            var lines = input.Split(new[] { '\r', '\n' });
            foreach (var message in lines)
            {
                if (string.IsNullOrEmpty(message))
                {
                    continue;
                }
                if (!_icondition.Exists(e => e.GetGoodsSymbol(message)))
                {
                    outputs.Add("I have no idea what you are talking about");
                }

            }            
        }
    }
}
