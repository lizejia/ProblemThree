using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    public class GalaxyCalculate
    {
        public List<string> GalaxyNumber { get; set; }
        public Dictionary<string, RomanNumbers> GalaxyNumberMapper { get; set; }

        public string Unit { get; set; }

        public Dictionary<string, decimal> GalaxyUnitMapper { get; set; }

        public GalaxyCalculate()
        {
            GalaxyNumber = new List<string>();
            GalaxyNumberMapper = new Dictionary<string, RomanNumbers>();
            GalaxyUnitMapper = new Dictionary<string, decimal>();
        }

        public decimal Calculate()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in GalaxyNumber)
            {
                stringBuilder.Append(GalaxyNumberMapper[item].ToString());
            }
            string romanStr = stringBuilder.ToString();
            RuleMain ruleMain = new RuleMain(romanStr);
            if (ruleMain.Check())
            {
                CalculateMain calculateMain = null;
                if (string.IsNullOrEmpty(Unit))
                    calculateMain = new CalculateMain(new NormalRomanCalculate(romanStr));
                else
                    calculateMain = new CalculateMain(new CreditsCalculate(romanStr, GalaxyUnitMapper[Unit]));

                return calculateMain.ExecuteStrategy();
            }
            return 0;
        }
    }
}
