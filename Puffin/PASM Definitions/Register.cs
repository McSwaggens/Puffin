using System;

namespace Puffin
{
	public class Register
	{
		public static int staticID = 0;
		public bool inFunction = false;
		public int id;
		
		public Register ()
		{
			id = staticID++;
		}
		
		public Register (int id)
		{
			this.id = id;
		}
		
		public string ToPASM ()
		{
			return (inFunction ? ":" : "") + id;
		}
	}
}

