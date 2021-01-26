using PiDigits.Code;
using System;

namespace PiDigits.ConsoleApp
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("Please enter digits of PI, one by one. You get a point for each digit guessed correctly.\nYou can miss up to 3 digits before the game ends.\n\n");

			BeginGuessing();
		}

		public static void BeginGuessing()
		{
			int points = 0;
			int fails = 0;
			bool floatingPoint = true;

			while (true)
			{
				char digit = Console.ReadKey().KeyChar;

				bool isCorrect = DigitChecker.CheckDigit(digit);

				if (isCorrect)
				{
					points++;
				}
				else
				{
					// Remove the digit and replace it with the correct one. Change its colour so that it's clear it was wrong.
					char correctDigit = DigitChecker.GetCorrectDigit(points + fails);
					Console.Write("\b");

					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write(correctDigit);
					Console.ForegroundColor = ConsoleColor.Gray;

					fails++;

					if (fails == 3)
					{
						// End the game.
						Console.WriteLine($"\nGame over. You scored {points} points!");
						return;
					}
				}

				if (floatingPoint)
				{
					// Add a comma after the first digit entered.
					Console.Write('.');
					floatingPoint = false;
				}
			}
		}
	}
}
