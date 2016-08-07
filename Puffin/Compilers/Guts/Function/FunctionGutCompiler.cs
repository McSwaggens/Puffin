using System;
using System.Collections.Generic;

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
			
			return result;
		}
		
		Block ScanBlocks (Token[] tokens)
		{
			Block rootBlock = new Block (null, context.function, null);
			
			rootBlock.Scan ();
			
			return rootBlock;
		}
	}
	
	internal class Block
	{
		public Token[] tokens;
		public FunctionContext context;
		public Block[] childBlocks;
		
		public Block (Token[] tokens, Function function, FunctionContext parentContext = null)
		{
			this.tokens = tokens;
			this.context = new FunctionContext (function, parentContext);
		}
		
		public void Scan ()
		{
			List<Block> blocks = new List<Block>();
			
			int index = 0;
			
			for (; index < tokens.Length; index++)
			{
				Token token = tokens[index];
				if (token is Operator && (token as Operator).type == OperatorType.OpeningBlockBracket)
				{
					List<Token> subTokens = new List<Token>();
					for (; index < tokens.Length; index++)
					{
						token = tokens[index];
						if (token is Operator && (token as Operator).type == OperatorType.ClosingBlockBracket)
						{
							Block subBlock = new Block (subTokens.ToArray(), context.function, context);
							blocks.Add (subBlock);
						}
						subTokens.Add (token);
					}
				}
			}
			
			childBlocks = blocks.ToArray();
		}
		
		public string[] Compile ()
		{
		}
	}
}

