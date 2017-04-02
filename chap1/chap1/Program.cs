using System;
using System.Collections.Generic;
using System.Text;

namespace chap1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			var ls = new LookAndSay();

			for (var i = 1; i <= 10; i++)
			{
				var output = ls.ant(i);
				Console.WriteLine(output);
			}

			Console.ReadLine();
		}

	}

	public class LookAndSay
	{
		public string ant(int n)
		{
			var input = "1";
			if (n == 1)
			{
				return input;
			}

			if (n <= 0)
			{
				throw new Exception("unsupported");
			}

			for (var i = 2; i <= n; i++)
			{
				input = next(input);
			}
			return input;
		}

		public string next(string input)
		{
			char last = ' ';
			int count = 0 ;
			var itor = input.GetEnumerator();
			var sb = new StringBuilder();

			while (itor.MoveNext())
			{
				if (count == 0)
				{
					last = itor.Current;
					count = 1;
				}
				else
					if (last != itor.Current)
				{
					//
					sb.Append(count.ToString());
					sb.Append(last);
					last = itor.Current;
					count = 1;
				}
				else
				{
					count++;
				}
			}


			sb.Append(count.ToString());
			sb.Append(last);

			return sb.ToString();
		}

	}


}
