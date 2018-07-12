﻿using System;
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
        public NormalRomanCalculate(List<SymbolValue> calculateSymbolList):base(calculateSymbolList)
        {
        }
        public override decimal CalculatePrice(decimal money)
        {
            return base.GetNormalPrice();
        }
    }
}