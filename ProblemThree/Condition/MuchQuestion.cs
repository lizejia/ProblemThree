using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemThree.Condition
{
    public class MuchQuestion : ICondition
    {
        private readonly Mapper _mapper;
        private readonly List<string> _outputList;
        public MuchQuestion(Mapper mapper,List<string> outputList)
        {
            this._mapper = mapper;
            this._outputList = outputList;
        }
        public bool GetSymbolValuesByMessage(string message)
        {
            var reg = Regex.Match(message, @"^how much is ([\w+\s]+) [\\?]$");
            if (reg.Success)
            {
                var metals = reg.Groups[1].Value;
                var GalaxyNumbers = Regex.Matches(metals, @"(\w+)");
                GalaxyCalculate galaxyCalculate = new GalaxyCalculate
                {
                    GalaxyNumberMapper = this._mapper.GetGalaxyNumbersMapper()
                };
                for (int i = 0; i < GalaxyNumbers.Count; i++)
                {
                    galaxyCalculate.GalaxyNumber.Add(GalaxyNumbers[i].Value);
                }
                var result = galaxyCalculate.Calculate();
                this._outputList.Add($"{metals} is {result}");
                return true;
            }
            return false;
        }
    }
}
