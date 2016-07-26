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
				foreach (ImportInformation import in file.body.imports)
				{
					PASM.Add(import.ToPASM());
				}
				
				
				Console.WriteLine($"Constructed {file.name}");
			}
			
			result.PASM = PASM.ToArray();
			
			return result;
		}
		
		
	}
}

