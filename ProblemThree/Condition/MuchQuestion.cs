using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProblemThree.Model;

namespace ProblemThree.Condition
{
    public class MuchQuestion : IGalaxyMessage
    {
        private readonly Mapper _mapper;
        private readonly List<string> _outputList;
        public MuchQuestion(Mapper mapper,List<string> outputList)
        {
            this._mapper = mapper;
            this._outputList = outputList;
        }
        public bool GetGalaxyNumber(string message)
        {
            //how much is pish tegj glob glob ?
            var reg = Regex.Match(message, @"^how much is ([\w+\s]+) [\\?]$");
            if (reg.Success)
            {
                var galaxyNumberStr = reg.Groups[1].Value;
                var galaxyNumberArr = galaxyNumberStr.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                GalaxyCalculate galaxyCalculate = new GalaxyCalculate
                {
                    GalaxyNumberMapper = this._mapper.GetGalaxyNumbersMapper(),
                    GalaxyNumber = galaxyNumberArr.ToList()
                };
                galaxyCalculate.Calculate();
                this._outputList.Add($"{galaxyNumberStr} is {galaxyCalculate.GalaxyNumberPrice}");
                return true;
            }
            return false;
        }
    }
}
