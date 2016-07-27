using System;
using System.Collections.Generic;

namespace Puffin
{
	public class Constructor
	{
		List<ConstructedFile> constructedFiles = new List<ConstructedFile>();
		
		List<string> PASM = new List<string>();
		
		public Constructor()
		{
		}
		
		public void Add (ConstructedFile file)
		{
			constructedFiles.Add(file);
		}
		
		public ConstructorResult Construct ()
		{
			ConstructorResult result = new ConstructorResult();
			foreach (ConstructedFile file in constructedFiles)
			{
				//Add all of the imports
				foreach (ImportInformation import in file.body.imports)
				{
					PASM.Add(import.ToPASM());
				}
				
				//Add all functions
				foreach (Function function in file.body.functions)
				{
					if (function.PASM == null)
					{
						Console.WriteLine ($"No PASM code was found for method {function.name}...");
					}
					else
					foreach (string line in function.PASM)
					{
						PASM.Add (line);
					}
				}
				
				Console.WriteLine($"Constructed {file.name}");
			}
			
			result.PASM = PASM.ToArray();
			
			return result;
		}
		
		
	}
}

