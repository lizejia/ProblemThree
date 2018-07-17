using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class CreditsQuestion : ICondition
    {
        private readonly Mapper _mapper;
        private readonly List<string> _outputList;
        public CreditsQuestion(Mapper mapper, List<string> outputList)
        {
            this._mapper = mapper;
            this._outputList = outputList;
        }
        public bool GetSymbolValuesByMessage(string message)
        {
            var reg = Regex.Match(message, @"^how many Credits is ([\w+\s]+) [\\?]$");
            if (reg.Success)
            {
                var metals = reg.Groups[1].Value;
                var metalCollection = Regex.Matches(metals, @"(\w+)");
                GalaxyCalculate galaxyCalculate = new GalaxyCalculate
                {
                    GalaxyNumberMapper = this._mapper.GetGalaxyNumbersMapper(),
                    GalaxyUnitMapper = this._mapper.GetUnitPriceMapper()
                };
                for (int i = 0; i < metalCollection.Count; i++)
                {
                    if (galaxyCalculate.GalaxyNumberMapper.Any(a => a.Key == metalCollection[i].Value))
                    {
                        galaxyCalculate.GalaxyNumber.Add(metalCollection[i].Value);
                    }
                    else
                    {
                        galaxyCalculate.Unit = metalCollection[i].Value;
                    }
                }

                var result = galaxyCalculate.Calculate();
                this._outputList.Add($"{metals} is {result.ToString("#.##")} Credits");
                return true;
            }
            return false;
        }
    }
}
