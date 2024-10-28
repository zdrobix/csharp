using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NumericType
{
	internal class Numeric
	{
		public Numeric() { }


		public static string wholeUnsignedNumber(BigInteger maxValue)
		{
			if (maxValue <= byte.MaxValue)
				return "byte";
			if (maxValue <= ushort.MaxValue)
				return "ushort";
			if (maxValue <= ulong.MaxValue)
				return "ulong";
			return "impossible representation";
		}

		public static string wholeSignedNumber(BigInteger minValue, BigInteger maxValue)
		{
			if (minValue >= sbyte.MinValue && maxValue <= sbyte.MaxValue)
				return "sbyte";
			if (minValue >= short.MinValue && maxValue <= short.MaxValue)
				return "short";
			if (minValue >= int.MinValue && maxValue <= int.MaxValue)
				return "int";
			if (minValue >= long.MinValue && maxValue <= long.MaxValue)
				return "long";
			return "impossible representation";
		}

		public static string wholeNumber(BigInteger minValue, BigInteger maxValue) =>
			minValue >= 0 ?
			wholeUnsignedNumber(maxValue) :
			wholeSignedNumber(minValue, maxValue);
		

		public static string preciseNumber(BigInteger minValue, BigInteger maxValue)
		{
			if (minValue >= new BigInteger(decimal.MinValue) && maxValue <= new BigInteger(decimal.MaxValue))
				return "decimal";
			return "impossible representation";
		}

		public static string notPreciseNumber(BigInteger minValue, BigInteger maxValue)
		{
			if (minValue >= new BigInteger(float.MinValue) && maxValue <= new BigInteger(float.MaxValue))
				return "float";
			if (minValue >= new BigInteger(double.MinValue) && maxValue <= new BigInteger(double.MaxValue))
				return "double";
			return "impossible representation";
		}

		public static string getType (string minValue, string maxValue, bool whole, bool precise)
		{
			BigInteger minValue_ = BigInteger.Parse (minValue);
			BigInteger maxValue_ = BigInteger.Parse (maxValue);
			return whole ? wholeNumber(minValue_, maxValue_) : 
				precise ? preciseNumber(minValue_, maxValue_) : notPreciseNumber(minValue_, maxValue_);
		}
	}
}
