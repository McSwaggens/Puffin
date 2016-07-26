using System;

namespace Puffin
{
	public class ConstructorResult
	{
		public string[] PASM;
		public ConstructorResult ()
		{
		}
		
		public void PrintPASM ()
		{
			Console.WriteLine($"Constructed PASM code ({PASM.Length}):");
			int i = 0;
			foreach (string line in PASM)
			{
				Console.WriteLine($"{i}\t{line}");
			}
		}
	}
}

