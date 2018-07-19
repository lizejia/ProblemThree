using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree.Model
{
    public enum RomanNumbers
    {
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000
    }

    public enum CalculateState
    {
        Credits,
        HowMuch,
        HowManyCredits
    }
}
