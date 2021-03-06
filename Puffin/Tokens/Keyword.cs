﻿using System;

namespace Puffin
{
	public class Keyword : Token
	{
		public EnumKeyword keyword = EnumKeyword.NO_KEYWORD;

		public Keyword (EnumKeyword keyword)
		{
			this.keyword = keyword;
		}

		public override string ToString ()
		{
			return "" + keyword.ToString();
		}
	}
}