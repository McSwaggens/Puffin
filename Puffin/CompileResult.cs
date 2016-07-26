using System;
using System.Collections.Generic;

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
		
		public void Set (ConstructorResult constructResult)
		{
			PASM = constructResult.PASM;
		}
	}
}

