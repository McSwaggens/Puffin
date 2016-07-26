using System;

namespace Puffin
{
	public class Boolean : ValueTokenType
	{
		public Boolean (string raw)
		{
			if (raw.ToLower() == "true")
				this.raw = true;
			else if (raw.ToLower() == "false")
				this.raw = false;
		}

		public override string ToString ()
		{
			return "" + raw;
		}
	}
}

