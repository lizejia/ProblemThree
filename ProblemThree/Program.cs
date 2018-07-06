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
            string input = @"glob is I
prok is V
pish is X
tegj is L
glob glob Silver is 34 Credits
glob prok Gold is 57800 Credits
pish pish Iron is 3910 Credits
how much is pish tegj glob glob ?
how many Credits is glob prok Silver ?
how many Credits is glob prok Gold ?
how many Credits is glob prok Iron ?
how much wood could a woodchuck chuck if a woodchuck could chuck wood ?";
            Console.WriteLine("Test input:");
            Console.WriteLine(input);

            MessageMain messageMain = new MessageMain();
            var output = messageMain.Start(input);
            Console.WriteLine("Test Output:");
            Console.WriteLine(output);

            Console.ReadKey();
        }
    }
}
