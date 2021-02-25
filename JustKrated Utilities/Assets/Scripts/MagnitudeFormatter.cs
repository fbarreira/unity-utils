using UnityEngine;

namespace JustKrated.Utils
{
	// Formats the order of magnitude up to 15 digits.
	public static class MagnitudeFormatter
	{
		/// <summary>
		/// Formats a given value to a shortened version.
		/// </summary>
		/// <param name="value">Value to be formatted.</param>
		/// <param name="minDigits">Minimum number of digits to be displayed.</param>
		/// <param name="minDecimals">Minimum number of decimals to be displayed.</param>
		/// <returns>The shortened representation.</returns>
		public static string Format (ulong value, int minDigits, int minDecimals)
		{
			int count = GetDigitsCount (value);

			if (count <= minDigits || value < 1000)
			{
				return value.ToString ();
			}
			else
			{
				var n = GetShortValue (value);

				var notation = GetNotation (count);
				return GetFormat (n, notation, minDecimals);
			}
		}

		public static string Format (ulong value)
		{
			return Format (value, 4, 2);
		}

		private static string GetFormat (float value, string notation, int minDecimals)
		{
			string format = "{0:.";

			for (int i = 0; i < minDecimals; i++)
			{
				format += "#";
			}

			format += "}{1}";

			return string.Format (format, value, notation);
		}

		public static float GetShortValue (ulong value)
		{
			if (value < 1000)
				return value;
			else if (value < 1000000)
				return DivideByPowerOfTen (value, 3);
			if (value < 1000000000)
				return DivideByPowerOfTen (value, 6);
			if (value < 1000000000000)
				return DivideByPowerOfTen (value, 9);
			else
				return DivideByPowerOfTen (value, 12);
		}

		/// <summary>
		/// Gets the digits quantity of a given number.
		/// </summary>
		/// <returns>The digits count.</returns>
		private static int GetDigitsCount (ulong n)
		{
			if (n >= 0)
			{
				if (n < 10) return 1;
				if (n < 100) return 2;
				if (n < 1000) return 3;                 // 1k
				if (n < 10000) return 4;
				if (n < 100000) return 5;
				if (n < 1000000) return 6;              // 1M
				if (n < 10000000) return 7;
				if (n < 100000000) return 8;
				if (n < 1000000000) return 9;           // 1B
				if (n < 10000000000) return 10;
				if (n < 100000000000) return 11;
				if (n < 1000000000000) return 12;       // 1T
				if (n < 10000000000000) return 13;
				if (n < 100000000000000) return 14;
				if (n < 1000000000000000) return 15;    // 1F
				return 16;
			}
			else
			{
				return 0;
			}
		}

		/// <summary>
		/// Get the notation based on a given quantity of digits.
		/// </summary>
		/// <param name="digits">Quantity of digits.</param>
		/// <returns>The notation.</returns>
		private static string GetNotation (int digits)
		{
			if (digits < 4) return "";          // < 1k
			if (digits < 7) return "k";         // < 1M
			if (digits < 10) return "M";        // < 1B
			if (digits < 13) return "B";        // < 1T
			else return "T";
		}

		public static string GetNotation (ulong value)
		{
			int count = GetDigitsCount (value);

			return GetNotation (count);
		}

		private static float DivideByPowerOfTen (ulong value, int exponent)
		{
			return value / (float)PowerOfTen (exponent);
		}

		private static ulong PowerOfTen (float exponent)
		{
			return (ulong)Mathf.Pow (10, exponent);
		}
	}

}