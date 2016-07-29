using System;

namespace Puffin
{
	public class FunctionGutCompiler
	{
		public FunctionContext context;
		
		private Token[] tokens;
		
		private int index = 0;
		
		private Token token
		{
			get
			{
				if (index < tokens.Length){
					return tokens[index];
				}
				return null;
			}
		}
		
		private Token NextToken ()
		{
			index++;
			return token;
		}
		
		public FunctionGutCompiler (Token[] tokens, Function function)
		{
			context = new FunctionContext (function);
			this.tokens = tokens;
		}
		
		public FunctionGutCompilerResult Compile ()
		{
			FunctionGutCompilerResult result = new FunctionGutCompilerResult ();
			
			for (; index < tokens.Length; NextToken ())
			{
			}
			
			return result;
		}
	}
}

