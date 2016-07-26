using System;

namespace Puffin
{
	public class ConstructedFile
	{
		public string name;
		public BodyCompilerResult body;
		//TODO: Add function guts result
		
		public ConstructedFile (string name, BodyCompilerResult body)
		{
			this.name = name;
			this.body = body;
		}
	}
}

