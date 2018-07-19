using ProblemThree.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class Tool
    {
        public static RomanNumbers ToRomanNumeral(string goodsName)
        {
            Enum.TryParse(goodsName, out RomanNumbers res);
            return res;
        }        
    }
}
