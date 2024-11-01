using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit;
using NUnit.Framework;

namespace passwordgen
{
	internal class Test
	{
		[TestCase(0, 0)]
		[TestCase(0, 10)]
		[TestCase(11, 10)]
		[TestCase(11, 10)]
		public void Validate_ShallThrowArgException_IfLengthsInvalid (int minLength, int maxLength)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => Validator.ValidateData(minLength, maxLength));
		}

		[Test]
		public void Generate_ShouldGeneratePasswordAAAAAA ()
		{
			var mockRandom = new Mock<Random>();
			mockRandom.Setup(random => random.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(7);
			mockRandom.Setup(random => random.Next(It.IsAny<int>())).Returns(0);
			var password = new PasswordGenerator(mockRandom.Object).Generate(5, 10, useSpecialCharacters: true);
			Assert.That(password.Length == 7);
			Assert.That(password == "AAAAAAA");
		}

		[Test]
		public void Generate_ShouldGeneratePasswordABCDEF()
		{
			var mockRandom = new Mock<Random>();
			mockRandom.Setup(random => random.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(6);
			mockRandom.SetupSequence(random => random.Next(It.IsAny<int>()))
				.Returns(0)
				.Returns(1)
				.Returns(2)
				.Returns(3)
				.Returns(4)
				.Returns(5);
			var password = new PasswordGenerator(mockRandom.Object).Generate(5, 10, useSpecialCharacters: true);
			Assert.That(password.Length == 6);
			Assert.That(password == "ABCDEF");
		}
	}
}
