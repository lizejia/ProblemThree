using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class Transform
    {
        public static RomanNumerals ToRomanNumeral(string goodsName)
        {
            RomanNumerals res;
            Enum.TryParse(goodsName, out res);
            return res;
        }
    }
}
