using System;

namespace Puffin
{
	public class Struct
	{
		public Point point;
		public string name;
		public VariablePreDefine[] variables;
		public Struct (string name, VariablePreDefine[] variables)
		{
			this.name = name;
			this.variables = variables;
			point = new Point();
		}
	}
}

