using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            uint i = 0;
            while (true)
            {
                i = i + 100000;
                Console.WriteLine(i);
            }
        }
    }
}
