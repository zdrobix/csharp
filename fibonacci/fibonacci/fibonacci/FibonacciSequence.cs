using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fib;

public class FibonacciSequence
{
	public static List<int>? getFibonacciSequence(int length_)
	{
		if (length_ < 0)
			throw new ArgumentException("cannot have negative length");

		if (length_ > 46)
			throw new ArgumentException("max number exceeded");


		var result = new List<int>();

		int a = -1;
		int b = 1;

		for (int i = 0; i < length_; i++)
		{
			int sum = a + b;
			result.Add(sum);
			a = b;
			b = sum;
		}
		return result;
	}
}