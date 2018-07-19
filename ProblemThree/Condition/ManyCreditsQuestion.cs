using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProblemThree.Model;

namespace ProblemThree.Condition
{
    public class ManyCreditsQuestion : IGalaxyMessage
    {
        private readonly Mapper _mapper;
        private readonly List<string> _outputList;
        public ManyCreditsQuestion(Mapper mapper, List<string> outputList)
        {
            this._mapper = mapper;
            this._outputList = outputList;
        }
        public bool GetGalaxyNumber(string message)
        {
            //how many Credits is glob prok Silver ?
            var reg = Regex.Match(message, @"^how many Credits is ([\w+\s]+) [\\?]$");
            if (reg.Success)
            {
                var galaxyNumberUnitStr = reg.Groups[1].Value;
                var galaxyNumberUnitArr = galaxyNumberUnitStr.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                GalaxyCalculate galaxyCalculate = new GalaxyCalculate
                {
                    GalaxyNumberMapper = this._mapper.GetGalaxyNumbersMapper(),
                    GalaxyUnitMapper = this._mapper.GetUnitPriceMapper()
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
                this._outputList.Add($"{galaxyNumberUnitStr} is {galaxyCalculate.CreditsPrice.ToString("#.##")} Credits");
                return true;
            }
            return false;
        }
    }
}
