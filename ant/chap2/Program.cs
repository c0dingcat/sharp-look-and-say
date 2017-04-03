using System;
using System.Text;
using System.Text.RegularExpressions;

namespace chap2
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var ant = new RegexAnt();
			var input = "1";
			Console.WriteLine(input);
			for (var i = 2; i < 15; i++)
			{
				input = ant.next(input);
				Console.WriteLine(input);
			}
		}
	}

	public class RegexAnt
	{
		const string pattern = "(.)\\1*";

		public string next(string input)
		{
			return input.Replace(pattern, source => source.Length.ToString() + source[0]);
		}
	}

	public static class RegExExtension
	{
		public static string Replace(this string input, string pattern, Func<string, string> func)
		{
			var sb = new StringBuilder();
			var regPattern = new Regex(pattern, RegexOptions.Compiled);
			foreach (Match match in regPattern.Matches(input))
			{
				sb.Append(func(match.Value));
			}

			return sb.ToString();

		}
	}
}
