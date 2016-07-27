using System;

namespace Puffin
{
	public class UserDefineType : Type
	{
		public Function initializer;
		public UserDefineType (string name, Function initializer)
		{
			this.name = name;
			this.initializer = initializer;
		}
	}
}

