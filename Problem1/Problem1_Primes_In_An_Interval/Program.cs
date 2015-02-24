using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Primes_In_An_Interval
{
    class Program
    {
        static bool isPrime(int number)
        {
            for (int iterator = 2; iterator < number - 1; iterator++)
            {
                if (number % iterator == 0)
                {
                    return false;
                }
            }
            return true;

        }
        static void primesInAnInterval(int from, int to)
        {
            string invalidInput = "Invalid input";
            if (from >= to)
            {
                Console.WriteLine(invalidInput);
                return;
            }
            else if (from < 2 || to < 2)
            {
                Console.WriteLine(invalidInput);
                return;
            }

            for (int iterator = from; iterator <= to; iterator++)
            {
                if (isPrime(iterator))
                {
                    Console.Write(iterator+" ");
                }
            }
        }
        static void Main(string[] args)
        {
            int firstNumber = 0;
            int secondNumber = 0;

            Console.WriteLine("Enter the first number: ");
            firstNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number: ");
            secondNumber = int.Parse(Console.ReadLine());

            primesInAnInterval(firstNumber, secondNumber);
        }
    }
}
