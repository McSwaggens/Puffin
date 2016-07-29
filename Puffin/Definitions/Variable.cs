using System;

namespace Puffin
{
	public class Variable
	{
		public Type type;
		public string name;
		public Register register;
		
		public Variable (Type type, string name, bool inFunction)
		{
			this.type = type;
			this.name = name;
			this.register = new Register (inFunction);
		}
		
		public Variable (Type type, string name, Register register)
		{
			this.type = type;
			this.name = name;
		}
		
		public bool IsBaseType ()
		{
			return type is PredefineType;
		}
		
		public bool IsUserDefinedType()
		{
			return type is UserDefineType;
		}
		
		public string ID
		{
			get
			{
				return register.ToPASM ();
			}
		}
	}
}

