using System;

namespace Puffin
{
	public class LexerResult
	{
		public Token[] tokens;
		
		public LexerResult (Token[] tokens)
		{
			this.tokens = tokens;
		}
		
		public void PrintTokens ()
		{
			int i = 0;
			foreach (Token token in tokens)
			{
				Console.WriteLine($"{i}:\t{token.ToString()}");
				i++;
			}
		}
	}
}

