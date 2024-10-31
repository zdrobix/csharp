using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordgen
{
	public class PasswordGenerator
	{
		public static string Generate(
			int minLength, int maxLength, bool useSpecialCharacters)
		{
			if (minLength < 1)
			{
				throw new ArgumentOutOfRangeException(
					$"leftRange must be greater than 0");
			}
			if (maxLength < minLength) { 
				throw new ArgumentOutOfRangeException(
					$"leftRange must be smaller than rightRange");
			}

			var lengthOfPassword = new Random().Next(minLength, maxLength + 1);

			var chars = useSpecialCharacters ?
				"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" :
				"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=";

			return new string(
				Enumerable.Repeat(chars, lengthOfPassword)
							.Select(
									chars => 
									chars[new Random().Next(chars.Length)])
							.ToArray());
		}
	}
}
