using System;

namespace Puffin
{
	public class BaseType : Type
	{
		public EnumBaseType baseType;
		public BaseType (string name, EnumBaseType baseType)
		{
			this.name = name;
			this.baseType = baseType;
		}
	}
}

