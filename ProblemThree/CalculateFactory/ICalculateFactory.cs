﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public interface ICalculateFactory
    {
        CalculateStrategy GetCalculateStrategy(MessageCategory messageCategory);
    }
}
