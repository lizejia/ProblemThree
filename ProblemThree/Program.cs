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
            string input = Tool.ReadTxtContent("input.txt");
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
