using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree.Condition
{
    interface ICondition
    {
        bool GetSymbolValuesByMessage(string message);
    }
}
