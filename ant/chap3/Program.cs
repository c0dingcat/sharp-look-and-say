using System;
using System.Collections.Generic;
using System.Linq;

namespace chap3
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var input = "1";
			Console.WriteLine(input);
			for (var i = 2; i <= 15; i++)
			{
				var output = string.Join(null, input.Group().Select(v => v.Count() + v[0]));
				Console.WriteLine(output);
				input = output;
			}
		}
	}

	public static class Extensions
	{
		public static List<List<string>> Group(this string input)
		{
			var ret = new List<List<string>>();

			char last = char.MinValue;
			int count = 0;
			List<string> current = null;

			for (var i = 0; i < input.Length; i++)
			{
				var ch = input[i];
				if (count == 0)
				{
					current = new List<string>();
					last = ch;
					count = 1;
				}
				else
					if (ch != last)
				{
					ret.Add(current);
					current = new List<string>();
					last = ch;
					count = 1;
				}
				else
				{
					count++;
				}
				current.Add(ch.ToString());
			}

			ret.Add(current);
			return ret;
		}

	}
}
