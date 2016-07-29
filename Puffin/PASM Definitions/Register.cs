using System;

namespace Puffin
{
	public class Register
	{
		public static int staticID = 0;
		public bool inFunction = false;
		public int id;
		
		public Register (bool inFunction)
		{
			id = staticID++;
			this.inFunction = inFunction;
		}
		
		public Register (int id, bool inFunction)
		{
			this.id = id;
			this.inFunction = inFunction;
		}
		
		public string ToPASM ()
		{
			return (inFunction ? ":" : "") + id;
		}
	}
}

