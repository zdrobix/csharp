using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordgen
{
	public class PasswordGenerator
	{
		private Random random;
		public PasswordGenerator(Random random_) {
			this.random = random_;
		}
		public string Generate(
			int minLength, int maxLength, bool useSpecialCharacters)
		{
			Validator.ValidateData(minLength, maxLength);

			var lengthOfPassword = this.random.Next(minLength, maxLength + 1);

			var chars = useSpecialCharacters ?
				"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" :
				"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=";

			return new string(
				Enumerable.Repeat(chars, lengthOfPassword)
							.Select(
									chars => 
									chars[this.random.Next(chars.Length)])
							.ToArray());
		}
	}
}
