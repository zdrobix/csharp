using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace stopwatch
{
	public static class __Stopwatch
	{
		private static DateTime? startTime;
		private static DateTime? stopTime;

		public static void Start()
		{
			if (startTime != null)
				throw new InvalidOperationException();
			startTime = DateTime.Now;
		}

		public static void Stop()
		{
			if (stopTime != null || startTime == null) 
				throw new InvalidOperationException();
			stopTime = DateTime.Now;
		}

		public static TimeSpan? getElapsed()
		{
			if (startTime == null)
				return TimeSpan.Zero;
			if (stopTime == null) 
				return null;

			return stopTime - startTime;
		}


	}
}
