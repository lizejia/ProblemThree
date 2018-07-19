using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree.Calculate
{
   public class ManyCalculate : CalculateStrategy
    {
        public Dictionary<string, decimal> GalaxyUnitMapper { get; set; }
        public string Unit { get; set; }
        public string ManyUnit { get; set; }
        public decimal Multiple { get; set; }
        public ManyCalculate()
        {
            GalaxyUnitMapper = new Dictionary<string, decimal>();
        }
        public override void Calculate()
        {
            base.NumberCalculate();
            Multiple = GalaxyUnitMapper[Unit] * GalaxyNumberPrice / GalaxyUnitMapper[ManyUnit];
        }
    }
}
