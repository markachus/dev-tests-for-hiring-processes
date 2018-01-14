using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringCalculator.Core;

namespace fr_stringcalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "XXX Company string calculator kata";
            Console.WriteLine("Follow instructions on 'readme.md'");
            string sInput = Console.ReadLine();

            int result = Calculator.Add(sInput);
            Console.WriteLine("Resultado = {0}" , result);
             
            Console.ReadLine();
        }
    }
}
