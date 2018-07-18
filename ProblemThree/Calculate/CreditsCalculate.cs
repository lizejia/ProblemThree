using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree.Calculate
{
    /// <summary>
    /// 没有被定义罗马数字的货物计算价格
    /// </summary>
    public class CreditsCalculate : CalculateStrategy
    {
        private readonly decimal _unitPrice;
        public CreditsCalculate(string romanStr, decimal unitPrice) : base(romanStr)
        {
            this._unitPrice = unitPrice;
        }
        public override decimal CalculatePrice()
        {
            return base.GetNormalPrice() * this._unitPrice;
        }
    }
}
