using fib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace fibonacci
{
	internal class TestFibonacci
	{
		[TestCase(-1)]
		[TestCase(-2)]
		[TestCase(-10)]
		public void getFibonacciSequence_ShallThrowException_IfLengthNegative(int invalidLength)
		{
			Assert.Throws<ArgumentException>(() => FibonacciSequence.getFibonacciSequence(invalidLength));
		}

		[TestCase(47)]
		[TestCase(48)]
		[TestCase(888)]
		public void getFibonacciSequence_ShallThrowException_IfLengthOver47(int invalidLength)
		{
			Assert.Throws<ArgumentException>(() => FibonacciSequence.getFibonacciSequence(invalidLength));
		}

		[TestCaseSource(nameof(getFibonacciSequenceTestCases))]
		public void getFibonacciSequence_ShallReturnValidResult7(int length, IEnumerable<int> expected)
		{
			var actual = FibonacciSequence.getFibonacciSequence(length);
			Assert.That(Compare(actual!, expected), $"Expected: {string.Join(", ", expected)}, Actual: {string.Join(", ", actual!)}");
		}

		private static IEnumerable<object> getFibonacciSequenceTestCases()
		{
			return new[]
			{
				new object[] {0, new int[] { } },
				new object[] {1, new int[] { 0} },
				new object[] {2, new int[] { 0, 1} },
				new object[] {3, new int[] { 0, 1, 1} },
				new object[] {4, new int[] { 0, 1, 1, 2} },
				new object[] {7, new int[] { 0, 1, 1, 2, 3, 5, 8} },
				new object[] {10, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34} },
				new object[] {13, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144} } 
			};
		}

		private static bool Compare(IEnumerable<int> expected, IEnumerable<int> actual)
		{
			if (expected.Count() != actual.Count())
				return false;
			for (int i = 0; i < expected.Count(); i++)
			{
				if (expected.ElementAt(i) != actual.ElementAt(i))
					return false;
			}
			return true;
		}
	}
}
