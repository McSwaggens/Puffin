using System;

namespace Puffin
{
	public class UserDefineType : Type
	{
		public Word name;
		public Function initializer;
		public UserDefineType (string name, Function initializer)
		{
			this.initializer = initializer;
			this.name = new Word(name);
		}
	}
}