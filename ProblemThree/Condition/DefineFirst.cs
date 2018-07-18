using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemThree.Condition
{
    public class DefineFirst : ICondition
    {
        private readonly Mapper _mapper;
        public DefineFirst(Mapper mapper)
        {
            this._mapper = mapper;
        }        

        public bool GetSymbolValuesByMessage(string message)
        {
            var reg = Regex.Match(message, @"(^\w+) is ([IVXLCDM])$");
            if (reg.Success)
            {
                string symbol = reg.Groups[2].Value;
                //添加直接定义值
                _mapper.AddGalaxyNumbers(reg.Groups[1].Value, Tool.ToRomanNumeral(symbol));
                return true;
            }
            return false;
        }
    }
}
