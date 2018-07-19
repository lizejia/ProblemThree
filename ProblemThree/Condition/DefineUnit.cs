using ProblemThree.Model;
using ProblemThree.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemThree.Condition
{
    public class DefineUnit : IGalaxyMessage
    {
        private readonly Mapper _mapper;
        public DefineUnit(Mapper mapper)
        {
            this._mapper = mapper;
        }
        
        public bool GetGalaxyNumber(string message)
        {
            //glob glob Silver is 34 Credits
            var reg = Regex.Match(message, @"([\w+\s]+) is (\d+) Credits");            
            if (reg.Success)
            {
                var creditPrice = decimal.Parse(reg.Groups[2].Value);
                var galaxyNumberUnitStr = reg.Groups[1].Value;
                var galaxyNumberUnitArr = galaxyNumberUnitStr.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                GalaxyCalculate galaxyCalculate = new GalaxyCalculate()
                {
                    GalaxyNumberMapper = this._mapper.GetGalaxyNumbersMapper(),
                    CreditsPrice = creditPrice
                };
                foreach (var item in galaxyNumberUnitArr)
                {
                    if (this._mapper.GetGalaxyNumbersMapper().Any(a => a.Key == item))
                    {
                        galaxyCalculate.GalaxyNumber.Add(item);
                    }
                    else
                    {
                        galaxyCalculate.Unit = item;
                    }
                }
                galaxyCalculate.Calculate();
                this._mapper.AddUnit(galaxyCalculate.Unit, galaxyCalculate.GalaxyUnitMapper[galaxyCalculate.Unit]);
                return true;
            }
            return false;
        }
    }
}
