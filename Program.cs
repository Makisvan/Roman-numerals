using System.Security.Cryptography.X509Certificates;

namespace Roman_numerals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bajskorv = "Y";
            while (bajskorv == "Y")
            {
                Dictionary<char, int> RomanNumeral = new Dictionary<char, int>()
            {
                { 'I',1}, { 'V',5}, { 'X',10}, { 'L',50}, { 'C',100}, { 'D',500}, { 'M',1000}

            };

                Console.WriteLine("Write a roman numeral ex. I/V/X/L/C/D/M");
                string input = Console.ReadLine().ToUpper();
                // int repeatCount = 1;

                if (input.Length > 11 )
                {
                    Console.WriteLine("Input must be 11 or lower");
                    break;
                }
                
                //if (input[i] > 0 && input[i] == input[input - 1])
                //{
                //    repeatCount++;
                //}
                //else 
                //{
                //    repeatCount = 1;
                //}
                //switch (input[i])
                //{
                //    case 'I':
                //    case 'X':
                //    case 'C':

                //        if (repeatCount > 3)
                //        {
                //            Console.WriteLine("Invalid input, cannot be more than 3 of the same symbol in a row");
                //            return;
                //        }
                //        break;

                //    case 'V':
                //    case 'L':
                //    case 'D':
                //        if (repeatCount > 1)
                //        {
                //            Console.WriteLine("Invalid input, cannot be more then 1 of the same symbol in a row");
                //            return;
                //        }
                //        break;
                //}

                int total = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    if (!RomanNumeral.ContainsKey(input[i]))
                    {
                        Console.WriteLine("Invalid input, try again");
                        break;
                    }
                    if (i + 1 < input.Length && RomanNumeral[input[i]] < RomanNumeral[input[i + 1]])
                    {
                        total -= RomanNumeral[input[i]];
                    }
                    else
                    {
                        total += RomanNumeral[input[i]];
                    }
                }

                Console.WriteLine("The corresponding numbers are:" + " " + total);
                Console.WriteLine("Would you like to play again? Y/N");
                bajskorv = Console.ReadLine().ToUpper();
            }
        }
    }
}
