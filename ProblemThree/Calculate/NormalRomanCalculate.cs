using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    /// <summary>
    /// 被定义有罗马数字的货物计算价格
    /// </summary>
    public class NormalRomanCalculate : CalculateStrategy
    {
        public NormalRomanCalculate(string romanStr) : base(romanStr)
        {
        }
        public override decimal CalculatePrice()
        {
            return base.GetNormalPrice();
        }
    }
}
