﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericType
{
	public class Data
	{
		private string minValue;
		private string maxValue;
		private bool wholeNumber;
		private bool veryPrecise;

		public Data(string minValue_, string maxValue_, bool wholeNumber_, bool veryPrecise_)
		{
			this.minValue = minValue_;
			this.maxValue = maxValue_;
			this.wholeNumber = wholeNumber_;
			this.veryPrecise = veryPrecise_;
		}

		public static bool validateData(string minValue_, string maxValue_, bool wholeNumber_, bool veryPrecise_)
		{
			if (wholeNumber_ && veryPrecise_)
				throw new Exception("A whole number cannot be precise");
			if (minValue_ == null || maxValue_ == null)
				throw new Exception("Cannot have null parameters");
			if (minValue_ == "" || maxValue_ == "")
				throw new Exception("Cannot have empty values");
			foreach (var ch in minValue_ + maxValue_)
				if (!"-0123987456".Contains(ch))
					throw new Exception("Invalid character.");
			long.TryParse(minValue_, out long longMinValue_);
			long.TryParse(maxValue_, out long longMaxValue_);
			if (longMinValue_ >= longMaxValue_)
				return false;
			return true;
		}
	}
}
