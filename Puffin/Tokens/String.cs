using System;

namespace Puffin
{
	public class String : ValueTokenType
	{
		public String (string raw)
		{
			this.raw = raw;
		}

		public override string ToString ()
		{
			return "" + raw;
		}
	}
}