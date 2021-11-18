using System;

namespace NumberChecker
{
    public enum NumberType
    {
        RegularNumber = 0,
        PrimeNumber = 1,
        MersennePrimeNumber = 2
    };

    internal class Program
    {
        static void Main(string[] args)
        {
            bool @continue = true;
            do
            {
                @continue = InputHandler(Console.ReadLine());
            } while (@continue);
        }

        static bool InputHandler(string input)
        {
            if (input == "quit")
                return false;

            if (int.TryParse(input, out int value))
            {
                var result = NumberChecker(value);
                string message = result switch
                {
                    NumberType.RegularNumber => "It is not a prime number",
                    NumberType.PrimeNumber => "It is a regular prime number",
                    NumberType.MersennePrimeNumber => "It is Mersenne prime number",
                    _ => "Somethng went wrong"
                };
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Inavlid number");
                return true;
            }

            return true;
        }

        static NumberType NumberChecker(int number)
        {
            bool IsValid(int number)
            {
                return !(number < 2);
            }

            if (!IsValid(number))
                return NumberType.RegularNumber;

            bool isPrime = IsPrime(number);
            if (isPrime)
            {
                if (IsMersennePrime(number))
                    return NumberType.MersennePrimeNumber;
                else
                    return NumberType.PrimeNumber;
            }
            else
                return NumberType.RegularNumber;

            //if (isPrime && IsMersennePrime(number))
            //    return NumberType.MersennePrimeNumber;
            //if (!ValidityChecker(number))
            //    return NumberType.RegularNumber;
            //if (IsMersennePrime(number))
            //    return NumberType.MersennePrimeNumber;
            //if (IsPrime(number))
            //    return NumberType.PrimeNumber;
        }

        static bool IsPrime(int number)
        {
            bool isPrime = true;
            for (int i = 2; i < Math.Sqrt(number); i++)
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }

            return isPrime;
        }

        static bool IsMersennePrime(int number)
        {
            for(int i=2;i<number+1;i*=2)
            {
                if (number == i - 1 || number == i + 1)
                    return true;
            }
            return false;
        }
    }
}
