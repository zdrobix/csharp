﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image_gen
{
	internal class GetAccess
	{
		public static List<string?>? getCredentials ()
		{
			using (var streamReader = new StreamReader("Q:\\info\\c# projects\\imagegen\\keyaccess.txt"))
			{
				return streamReader.ReadToEnd().Split('\n').ToList()!;
			}
		}
	}
}