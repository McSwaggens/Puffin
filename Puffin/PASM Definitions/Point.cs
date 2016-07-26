using System;

namespace Puffin
{
	public class Point
	{
		public static int staticID = 0;
		public bool inFunction = false;
		public int id;
		
		public Point ()
		{
			id = staticID++;
		}
		
		public Point (int id)
		{
			this.id = id;
		}
		
		public string ToPASM ()
		{
			return (inFunction ? ":" : "") + id;
		}
	}
}

