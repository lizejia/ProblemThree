using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemThree.Calculate;
using ProblemThree.Model;

namespace ProblemThree.Condition
{
    public class ManyQuestion : IGalaxyMessage
    {
        private readonly Mapper _mapper;
        private readonly List<string> _outputList;
        public ManyQuestion(Mapper mapper,List<string> outputList)
        {
            this._mapper = mapper;
            this._outputList = outputList;
        }
        public bool GetGalaxyNumber(string message)
        {
            //how many Silver is glob Gold ?
            var messageSpilt = message.Split(new string[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
            if (messageSpilt[0].StartsWith("how many") && !messageSpilt[0].EndsWith("Credits") && messageSpilt[1].EndsWith("?"))
            {
                var manyUnitStr = messageSpilt[0].Replace("how many", "").Trim();
                var galaxyUnitStr = messageSpilt[1].Replace("?", "").Trim();
                var galaxyUnitArr = galaxyUnitStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ManyCalculate galaxyCalculate = new ManyCalculate
                {
                    GalaxyNumberMapper = _mapper.GetGalaxyNumbersMapper(),
                    GalaxyUnitMapper = _mapper.GetUnitPriceMapper(),
                };
                foreach (var item in galaxyUnitArr)
                {
                    if (this._mapper.GetGalaxyNumbersMapper().Any(a => a.Key == item))
                    {
                        galaxyCalculate.GalaxyNumber.Add(item);
                    }
                    else
                    {
                        galaxyCalculate.Unit = item;
                        galaxyCalculate.ManyUnit = manyUnitStr;
                    }
                }
                galaxyCalculate.Calculate();
                this._outputList.Add($"{galaxyUnitStr} is {galaxyCalculate.Multiple} {manyUnitStr}");
                return true;
            }
            return false;
        }
    }
}
