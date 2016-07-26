﻿using System;

namespace Puffin
{
	
	public class Token
	{
		//Base token to be extended into other classes, this acts as a base

		public object raw;

		public string GetDefinitionString()
		{
			string ret = $"[{this.GetType().ToString().Substring(11)}]  \t{ToString()}";
			return ret;
		}
	}
}

