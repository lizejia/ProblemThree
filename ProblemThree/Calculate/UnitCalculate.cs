using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree.Calculate
{
    public class UnitCalculate : CalculateStrategy
    {
        private readonly decimal _unitPrice;
        private readonly decimal _manyUnitPrice;
        public UnitCalculate(string romanStr, decimal unitPrice, decimal manyUnitPrice) : base(romanStr)
        {
            this._unitPrice = unitPrice;
            this._manyUnitPrice = manyUnitPrice;
        }

        public override decimal CalculatePrice()
        {
            return base.GetNormalPrice() * this._unitPrice / this._manyUnitPrice;
        }
    }
}
