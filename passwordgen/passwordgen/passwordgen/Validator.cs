using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordgen
{
	internal class Validator
	{
		public static void ValidateData(int? minLength, int? maxLength)
		{
			if (minLength < 1)
			{
				throw new ArgumentOutOfRangeException(
					$"leftRange must be greater than 0");
			}
			if (maxLength < minLength)
			{
				throw new ArgumentOutOfRangeException(
					$"leftRange must be smaller than rightRange");
			}
		}
	}
}
