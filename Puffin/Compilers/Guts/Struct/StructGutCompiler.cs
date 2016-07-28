using System;
using System.Collections.Generic;

namespace Puffin
{
	public class StructGutCompiler
	{
		private Token[] tokens;
		
		private int i = 0;
		
		private Token token
		{
			get
			{
				if (i < tokens.Length){
					return tokens[i];
				}
				return null;
			}
		}
		
		private Token NextToken ()
		{
			i++;
			return token;
		}
		
		public StructGutCompiler(Token[] tokens)
		{
			this.tokens = tokens;
		}
		
		public StructGutCompilerResult Compile ()
		{
			StructGutCompilerResult result = new StructGutCompilerResult ();
			
			int index = 2;
			
			ulong size = 0;
			
			List<string> pasm = new List<string>();
			
			for (; i < tokens.Length; i++)
			{
				if (token is Word)
				{
					Word wtype = token as Word;
					if (TypeUtil.DoesPredefinedTypeExist (wtype))
					{
						NextToken();
						
						PredefineType type = TypeUtil.GetPredefinedType(wtype);
						
						if (token is Word)
						{
							Word name = token as Word;
							
							NextToken();
							
							object _default = type.default_value;
							
							if (token is Operator && (token as Operator).type == OperatorType.Equals)
							{
								NextToken();
								if (token is Integer)
								{
									Integer number = token as Integer;
									_default = number.raw;
									NextToken ();
								}
							}
							
							if (token is Operator && (token as Operator).type == OperatorType.SemiColon)
							{
								pasm.Add ($"set :1 PARD :0 {size} {type.size}");
								pasm.Add ($"set :1 {type.alias_pasm} {_default}");
							}
							else
							{
								throw new PuffinException ($"Unexpected token (\"{token.raw}\" of type \"{token}\")");
							}
							
							size += type.size;
						}
						else
						{
							throw new PuffinException ($"Unexpected token (\"{token.raw}\" of type \"{token}\")");
						}
					}
					else
					{
						throw new PuffinException ($"Invalid Puffin type {token.raw}");
					}
				}
				else
				{
					throw new PuffinException ($"Unexpected token (\"{token.raw}\" of type \"{token}\")");
				}
			}
			
			result.PASM = pasm.ToArray();
			result.size = size;
			
			return result;
		}
	}
}

