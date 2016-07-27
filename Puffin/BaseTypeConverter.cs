using System;
using System.Collections.Generic;

namespace Puffin
{
	public class BaseTypeConverter
	{
		private static Dictionary<EnumBaseType, string> baseTypes = new Dictionary<EnumBaseType, string>()
		{
			{EnumBaseType.UBYTE, "BYTE"},
			{EnumBaseType.USHORT, "INT16"},
			{EnumBaseType.UINT, "INT32"},
			{EnumBaseType.ULONG, "INT64"},
			
			{EnumBaseType.BYTE, "SBYTE"},
			{EnumBaseType.SHORT, "SINT16"},
			{EnumBaseType.INT, "SINT32"},
			{EnumBaseType.LONG, "SINT64"},
			
			{EnumBaseType.PTR, "INT32"}
		};
		
		public static string Convert (EnumBaseType type)
		{
			foreach (KeyValuePair<EnumBaseType, string> pair in baseTypes)
			{
				if (pair.Key == type)
					return pair.Value;
			}
			throw new Exception ($"Error converting type {type.ToString()} (NO KNOWN CONVERT FOUND!)");
		}
	}
}

