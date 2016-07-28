using System;

namespace Puffin
{
	public class TypeUtil
	{
		public static bool DoesPredefinedTypeExist (Word word)
		{
			foreach (PredefineType type in PredefineType.declared_pasm_types)
			{
				if (type.alias_lc == word.raw as string)
				{
					return true;
				}
			}
			return false;
		}
		
		public static PredefineType GetPredefinedType (Word word)
		{
			foreach (PredefineType type in PredefineType.declared_pasm_types)
			{
				if (type.alias_lc == word.raw as string)
				{
					return type;
				}
			}
			throw new Exception ($"Unable to find type {word.raw as string}");
		}
	}
}

