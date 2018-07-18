using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class GalaxyCalculateFactory : ICalculateFactory
    {

        public GalaxyCalculateFactory()
        {

        }
        public CalculateStrategy GetCalculateStrategy(MessageCategory messageCategory)
        {
            CalculateStrategy calculateStrategy = null;
            switch (messageCategory)
            {
                case MessageCategory.Define:
                    calculateStrategy = new NumbersCalculate("");
                    break;
                case MessageCategory.ManyCredits:
                    calculateStrategy = new NumbersCalculate("");
                    break;
                case MessageCategory.Much:
                    break;
                case MessageCategory.ManyUnit:
                    break;
                default:
                    throw new NotImplementedException();
            }
            return calculateStrategy;
        }
    }
}
