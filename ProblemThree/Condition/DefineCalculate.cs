using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemThree.Condition
{
    public class DefineCalculate : ICondition
    {
        private readonly Mapper _mapper;
        public DefineCalculate(Mapper mapper)
        {
            this._mapper = mapper;
        }
        public bool GetSymbolValuesByMessage(string message)
        {
            var reg = Regex.Match(message, @"([\w+\s]+) is (\d+) Credits");            
            if (reg.Success)
            {                
                var metals = reg.Groups[1].Value;
                var metalCollection = Regex.Matches(metals, @"(\w+)");
                GalaxyCalculate galaxyCalculate = new GalaxyCalculate
                {
                    GalaxyNumberMapper = this._mapper.GetGalaxyNumbersMapper()
                };
                string unitStr = "";
                for (int i = 0; i < metalCollection.Count; i++)
                {
                    if (galaxyCalculate.GalaxyNumberMapper.Any(a => a.Key == metalCollection[i].Value))
                    {
                        galaxyCalculate.GalaxyNumber.Add(metalCollection[i].Value);
                    }
                    else
                    {
                        unitStr = metalCollection[i].Value;
                    }                    
                }
                var result = galaxyCalculate.Calculate();
                var unitPrice = decimal.Parse(reg.Groups[2].Value) / result;
                this._mapper.AddUnit(unitStr, unitPrice);
                return true;
            }
            return false;
        }
    }
}
