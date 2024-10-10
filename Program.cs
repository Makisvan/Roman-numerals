using System;
using System.Collections.Generic;

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
                    { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 }
                };

                Console.WriteLine("Write a roman numeral ex. I/V/X/L/C/D/M");
                string input = Console.ReadLine().ToUpper();

                // Kontrollera om inmatningen är för lång
                if (input.Length > 11)
                {
                    Console.WriteLine("Input must be 11 characters or less.");
                    continue;
                }

                int total = 0;
                int repeatCount = 1;
                bool invalidInput = false; // Flagga för att hantera ogiltig inmatning

                for (int i = 0; i < input.Length; i++)
                {
                    // Kontrollera om tecknet finns i uppslagslistan
                    if (!RomanNumeral.ContainsKey(input[i]))
                    {
                        Console.WriteLine("Invalid input, try again.");
                        invalidInput = true;
                        break;
                    }

                    // Kontrollera om samma tecken upprepas flera gånger
                    if (i > 0 && input[i] == input[i - 1])
                    {
                        repeatCount++;
                    }
                    else
                    {
                        repeatCount = 1; // Återställ räknaren om ett nytt tecken dyker upp
                    }

                    // Använd switch för att kontrollera om antalet upprepade tecken är giltigt
                    switch (input[i])
                    {
                        case 'I':
                        case 'X':
                        case 'C':
                            if (repeatCount > 3)
                            {
                                Console.WriteLine("Invalid input: Cannot be more than 3 of the same symbol in a row.");
                                invalidInput = true;
                            }
                            break;
                        case 'V':
                        case 'L':
                        case 'D':
                            if (repeatCount > 1)
                            {
                                Console.WriteLine("Invalid input: Cannot be more than 1 of the same symbol in a row.");
                                invalidInput = true;
                            }
                            break;
                    }

                    if (invalidInput)
                    {
                        break; // Stoppa loopen om ogiltig inmatning hittas
                    }

                    // Om nuvarande siffra är mindre än nästa, subtrahera, annars addera
                    if (i + 1 < input.Length && RomanNumeral[input[i]] < RomanNumeral[input[i + 1]])
                    {
                        total -= RomanNumeral[input[i]];
                    }
                    else
                    {
                        total += RomanNumeral[input[i]];
                    }
                }

                // Om ingen ogiltig inmatning hittades, visa resultatet
                if (!invalidInput)
                {
                    Console.WriteLine("The corresponding number is: " + total);
                }

                // Fråga om användaren vill spela igen
                Console.WriteLine("Would you like to play again? Y/N");
                bajskorv = Console.ReadLine().ToUpper();
            }
        }
    }
}
