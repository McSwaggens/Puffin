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
			
			uint size = 1;
			
			int index = 1;
			
			pasm.Add ($"malloc_d :0 {size}");
			
			pasm.Add ($"re :0");
			
			PASM = pasm.ToArray ();
		}
	}
}

