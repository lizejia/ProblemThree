using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree.Calculate
{
    public class ManyCreditsCalculate : CalculateStrategy
    {
        public Dictionary<string, decimal> GalaxyUnitMapper { get; set; }
        public string Unit { get; set; }
        public decimal CreditsPrice { get; set; }
        public ManyCreditsCalculate()
        {
            GalaxyUnitMapper = new Dictionary<string, decimal>();
        }
        public override void Calculate()
        {
            base.NumberCalculate();
            CreditsPrice = GalaxyUnitMapper[Unit] * GalaxyNumberPrice;
        }
    }
}
