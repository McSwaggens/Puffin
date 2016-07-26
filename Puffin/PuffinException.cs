using System;

namespace Puffin
{
	public class PuffinException : Exception
	{
		public PuffinException (string error) : base (error)
		{
			//Output the error to the console (TEMP)
			Console.WriteLine($"[ERROR] {error}");
		}
	}
}

