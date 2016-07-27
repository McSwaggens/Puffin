using System;

namespace Puffin
{
	public class UserDefineType : Type
	{
		public PFunction initializer;
		public UserDefineType (string name, PFunction initializer)
		{
			this.name = name;
			this.initializer = initializer;
		}
	}
}

