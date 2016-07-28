using System;
using System.Collections.Generic;

namespace Puffin
{
	public class Struct
	{
		public Point point;
		public string name;
		
		public string[] PASM;
		
		private Token[] tokens;
		
		public Struct (string name, Token[] tokens)
		{
			this.name = name;
			this.tokens = tokens;
			point = new Point();
		}
		
		public void Compile ()
		{
			List<string> pasm = new List<string>();
			
			pasm.Add ($"pt {point.id}");
			
			StructGutCompiler compiler = new StructGutCompiler(tokens);
			
			StructGutCompilerResult compilation_result = compiler.Compile();
			
			pasm.Add ($"malloc_d :0 {compilation_result.size}");
			
			foreach (string str in compilation_result.PASM)
			{
				pasm.Add (str);
			}
			
			pasm.Add ($"re :0");
			
			PASM = pasm.ToArray ();
		}
	}
}

