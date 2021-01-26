using System.IO;

namespace PiDigits.Code
{
	public class DigitChecker
	{
		const string PATH = @"PI.txt";

		public static string PI;
		public static int Position = 0;

		static DigitChecker()
		{
			using var reader = new StreamReader(PATH);

			PI = reader.ReadToEnd();
		}

		public static bool CheckDigit(char digit)
		{
			if (PI[Position++] == digit)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static char GetCorrectDigit(int pos)
		{
			return PI[pos];
		}
	}
}
