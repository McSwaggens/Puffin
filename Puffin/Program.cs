using System;
using System.IO;

namespace Puffin
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Check if the user has entered in in a file to be compiled.
			if (args.Length == 0)
			{
				Console.WriteLine("Please enter a file to be compiled...");
				return; // Exit the program
			}
			
			//Check if the file entered actually exists.
			if (!File.Exists(args[0]))
			{
				Console.WriteLine($"[ERROR] File {args[0]} does not exist!");
				return; // Exit the program
			}
			
			//File entered by the user
			string target = args[0];
			
			//Create a compiler instance
			Compiler compiler = new Compiler(target);
			
			//Compile the source code into PASM, returning the outputted data to a CompileResult object
			CompileResult result = compiler.Compile();
			
			//Write the compiled code to the output file
			result.WriteOutput (compiler.outputFileInformation);
		}
	}
}