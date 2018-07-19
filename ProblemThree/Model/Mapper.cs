using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree.Model
{
    public class Mapper
    {
        private Dictionary<string, RomanNumbers> _galaxyNumbersDic;
        private Dictionary<string, decimal> _unitNumbersDic;
        public Mapper()
        {
            _galaxyNumbersDic = new Dictionary<string, RomanNumbers>();
            _unitNumbersDic = new Dictionary<string, decimal>();
        }

        public void AddUnit(string name, decimal value)
        {
            _unitNumbersDic.Add(name, value);
        }

        public Dictionary<string, decimal> GetUnitPriceMapper()
        {
            return _unitNumbersDic;
        }

        public void AddGalaxyNumbers(string name, RomanNumbers romanNumeral)
        {
            _galaxyNumbersDic.Add(name, romanNumeral);
        }

        public Dictionary<string, RomanNumbers> GetGalaxyNumbersMapper()
        {
            return _galaxyNumbersDic;
        }
    }
}
