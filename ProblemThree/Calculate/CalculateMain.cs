using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class CalculateMain
    {
        private CalculateStrategy _calculateStrategy;
        public CalculateMain(CalculateStrategy calculateStrategy)
        {
            this._calculateStrategy = calculateStrategy;
        }


        public decimal ExecuteStrategy(decimal money)
        {
            return _calculateStrategy.CalculatePrice(money);
        }

    }
}
