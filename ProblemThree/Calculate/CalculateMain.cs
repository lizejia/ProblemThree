using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree.Calculate
{
    public class CalculateMain
    {
        private CalculateStrategy _calculateStrategy;
        public CalculateMain(CalculateStrategy calculateStrategy)
        {
            this._calculateStrategy = calculateStrategy;
        }


        public decimal ExecuteStrategy()
        {
            return _calculateStrategy.CalculatePrice();
        }

    }
}
