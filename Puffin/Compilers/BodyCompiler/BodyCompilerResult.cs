using System;
using System.Collections.Generic;

namespace Puffin
{
	public class BodyCompilerResult
	{
		//List of imports found
		public List<ImportInformation> imports = new List<ImportInformation>();
		
		//List of structs found
		public List<Struct> structs = new List<Struct>();
		
		//List of functions found
		public List<Function> functions = new List<Function>();
		
		//List of initialized variables
		public List<Variable> variables = new List<Variable>();

        public void PrintContents()
        {
			Console.WriteLine ($"Imports({imports.Count}):");
			foreach (ImportInformation import in imports)
			{
				Console.WriteLine($"\t{import.import}");
			}
			
			Console.WriteLine ($"Functions({functions.Count}):");
			foreach (Function function in functions)
			{
				Console.WriteLine ($"\tName:\"{function.name}\"\n\tPublic:\"{function.isPublic}\"\n");
			}
			
			Console.WriteLine ($"Structs({structs.Count}):");
			foreach (Struct stru in structs)
			{
				Console.WriteLine ($"\tName:\"{stru.name}\"\n\tSize:{stru.size}");
			}
        }

        public void CompileFunctions()
        {
			foreach (Function function in functions)
			{
				function.Compile ();
				Console.WriteLine ($"Function {function.name} compiled...");
			}
        }
		
		public void CompileStructs()
        {
			foreach (Struct stru in structs)
			{
				stru.Compile ();
				Console.WriteLine ($"Struct {stru.name} compiled...");
			}
        }
    }
}

