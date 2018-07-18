using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree.Rules
{
    public class RuleMain
    {
        private readonly List<IRule> _iruleList;
        public RuleMain(string romanStr)
        {
            this._iruleList = new List<IRule> {
                                        new RepeatCheck(romanStr),
                                        new SubtractCheck(romanStr)
                                     };
        }
        
        public bool Check()
        {
            return !_iruleList.Exists(f => !f.Check());
        }
    }
}
