using System;
using System.Text;

namespace Задача_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Polynomial polynomial1 = new Polynomial();
            Polynomial polynomial2 = new Polynomial();

            polynomial1.Add(polynomial2);
            Console.WriteLine(polynomial1.ToString());

            Console.ReadKey();
        }
    }
}
