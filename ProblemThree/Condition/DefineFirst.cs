﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class DefineFirst : ICondition
    {
        private readonly MessageMain _messageMain;
        public DefineFirst(MessageMain messageMain)
        {
            this._messageMain = messageMain;
        }        

        public bool GetSymbolValuesByMessage(string message)
        {
            var reg = Regex.Match(message, @"(^\w+) is ([IVXLCDM])$");
            if (reg.Success)
            {
                string symbol = reg.Groups[2].Value;
                //添加直接定义值
                _messageMain.GoodsNameSymbol.Add(reg.Groups[1].Value, new SymbolValue
                                                        {
                                                            Symbol = Convert.ToChar(symbol),
                                                            Value = (decimal)Tool.ToRomanNumeral(symbol)
                                                        });
                return true;
            }
            return false;
        }
    }
}
