using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Puffin
{
	public class CompileResult
	{
		public string[] PASM;
		public List<PuffinException> errors;
		public List<string> warnings;
		
		public CompileResult ()
		{
		}
		
	
		public void WriteOutput (FileInformation outputFile)
		{
			//Check if the file already exists
			if (File.Exists (outputFile.file))
			{
				//Delete the existing file
				File.Delete (outputFile.file);
			}
			
			//Create a new file for our new compiled PASM code
			File.Create (outputFile.file).Close();
			
			Thread.Sleep (100);

			//Write the PASM to the newly created file
			File.WriteAllLines (outputFile.file, PASM);
		}
		
		public void Set (ConstructorResult constructResult)
		{
			PASM = constructResult.PASM;
		}
	}
}

