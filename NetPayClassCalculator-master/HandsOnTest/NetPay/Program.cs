using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPay
{
    class Program
    {
        static void Main(string[] args)
        {

            double salary = PromptSalary();
            CalculateNetPay(salary);
            CalculateNetPay(salary, insurance: 300);
            //CalculateNetPay(salary, taxes: .1);
            Console.ReadLine();

        }

        public static double PromptSalary()
        {
            double salary;
            Console.WriteLine("Input Your Annual Salary:");
            bool valid = Double.TryParse(Console.ReadLine(), out salary);
            while (!(valid))
            {
                Console.WriteLine("try again:");
                valid = Double.TryParse(Console.ReadLine(), out salary);
            }
            return salary;
        }
        public static void CalculateNetPay(double salary, int insurance = 100, double taxes = .3)
        {
            int num;
            start:
            Console.WriteLine();
            Console.WriteLine("type 1 for Gross Pay");
            Console.WriteLine("type 2 for Net Pay Before Taxes");
            Console.WriteLine("type 3 for Net Pay Before Insurance");
            double GrossPay = salary;
            double NetPayTaxFree = GrossPay - insurance;
            double NetPayInsuranceFree = GrossPay * taxes;
            double newTax = GrossPay - NetPayInsuranceFree;
            if (Int32.TryParse(Console.ReadLine(), out num))
            {
                if (num == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Gross Pay: {0:0,00.##}\n", GrossPay);
                    Console.ResetColor();
                    goto start;
                }
                if (num == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Net Pay With Insurance But Before Taxes: {0:0,00.##}\n", NetPayTaxFree);
                    Console.ResetColor();
                    goto start;
                }
                if (num == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Net Pay With Insurance But Before Taxes: {0:0,00.##}\n", newTax);
                    Console.ResetColor();
                    goto start;
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Entry\n");
                Console.ResetColor();
                goto start;
            }
            
        }
    }
}
