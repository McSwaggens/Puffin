using System;
using System.Collections.Generic;

namespace Puffin
{
	public class PredefineType : Type
	{
		public static PredefineType[] declared_pasm_types = new List<PredefineType>()
		{
			new PredefineType("byte",	"BYTE", 1, 0), 		// byte
			new PredefineType("sbyte",	"SBYTE", 1, 0), 	// sbyte
			
			new PredefineType("bool",	"BYTE", 1, 0), 		// bool -> byte
			
			new PredefineType("ushort",	"INT16", 2, 0), 	// ushort
			new PredefineType("short",	"SINT16", 2, 0), 	// short
			
			new PredefineType("uint",	"INT32", 4, 0), 	// uint
			new PredefineType("int",		"SINT32", 4, 0), 	// int
			
			new PredefineType("ulong",	"INT64", 8, 0), 	// ulong
			new PredefineType("long",	"SINT64", 8, 0), 	// long
			
			//TODO: Add more PASM types
			
		}.ToArray();
		
		public string alias_lc;
		public string alias_pasm;
		public object default_value;
		
		public PredefineType (string alias_lc, string alias_pasm, ulong size, object default_value)
		{
			this.alias_lc = alias_lc;
			this.alias_pasm = alias_pasm;
			this.size = size;
			this.default_value = default_value;
		}
	}
}

