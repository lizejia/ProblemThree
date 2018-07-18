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
    public class NumbersCalculate : CalculateStrategy
    {
        public override decimal CalculatePrice(string romanStr)
        {
            return base.NumberCalculate(romanStr);
        }
    }
}
