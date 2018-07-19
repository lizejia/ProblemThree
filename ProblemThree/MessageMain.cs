using ProblemThree.Condition;
using ProblemThree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class MessageMain
    {
        private readonly Mapper _mapper;
        private readonly List<IGalaxyMessage> _iconditionList;
        private readonly List<string> _outputList;
        public MessageMain()
        {
            _mapper = new Mapper();
            _outputList = new List<string>();
            _iconditionList = new List<IGalaxyMessage> {
                                        new DefineInformation(_mapper),
                                        new DefineUnit(_mapper),
                                        new MuchQuestion(_mapper,_outputList),
                                        new ManyCreditsQuestion(_mapper,_outputList),
                                        new ManyQuestion(_mapper,_outputList)
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
                if (!_iconditionList.Exists(e => e.GetGalaxyNumber(message)))
                {
                    _outputList.Add("I have no idea what you are talking about");
                }
            }
            return string.Join("\r\n", _outputList);
        }
    }
}
