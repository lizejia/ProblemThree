using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemThree
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageMain Messmain = new MessageMain();
            var input = "glob is I\r\nprok is V\r\npish is X\r\ntegj is L\r\nglob glob Silver is 34 Credits\r\n" +
                        "glob prok Gold is 57800 Credits\r\npish pish Iron is 3910 Credits\r\n" +
                        "how much is pish tegj glob glob ?\r\nhow many Credits is glob prok Silver ?\r\n" +
                        "how many Credits is glob prok Gold ?\r\nhow many Credits is glob prok Iron ?\r\n" +
                        "how much wood could a woodchuck chuck if a woodchuck could chuck wood ?";
            var expected = "pish tegj glob glob is 42\r\nglob prok Silver is 68 Credits\r\n" +
                           "glob prok Gold is 57800 Credits\r\nglob prok Iron is 782 Credits\r\n" +
                           "I have no idea what you are talking about";
            Messmain.GetGoodsSymbol(input);



            //string symbolStr = "XXXDM";
            //CalculateMain sm = new CalculateMain(symbolStr);
            // sm.Check();

            Console.ReadKey();
        }
    }
}
