using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class ManyQuestion : ICondition
    {
        private readonly Mapper _mapper;
        private readonly List<string> _outputList;
        public ManyQuestion(Mapper mapper,List<string> outputList)
        {
            this._mapper = mapper;
            this._outputList = outputList;
        }
        public bool GetSymbolValuesByMessage(string message)
        {
            var messageSpilt = message.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
            if (messageSpilt[0].StartsWith("how many") && !messageSpilt[0].EndsWith("Credits") && messageSpilt[1].EndsWith("?"))
            {
                var manyUnitStr = messageSpilt[0].Replace("how many", "").Trim();
                var unitWord = messageSpilt[1].Replace("?", "").Trim();
                var unitWords = unitWord.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                GalaxyCalculate galaxyCalculate = new GalaxyCalculate
                {
                    ManyUnit = manyUnitStr,
                    Unit = unitWords[1],
                    GalaxyNumberMapper = _mapper.GetGalaxyNumbersMapper(),
                    GalaxyUnitMapper = _mapper.GetUnitPriceMapper()
                };
                galaxyCalculate.GalaxyNumber.Add(unitWords[0]);
                var result = galaxyCalculate.Calculate();
                this._outputList.Add($"{unitWord} is {result} {manyUnitStr}");
                return true;
            }
            return false;
        }
    }
}
