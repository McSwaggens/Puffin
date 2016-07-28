using System;
using System.Collections.Generic;

namespace Puffin
{
	public class BodyCompiler
	{
		private BodyCompilerResult result = new BodyCompilerResult();
		private LexerResult lexerResult;
		private Token[] tokens;
		
		//Current token index;
		private int i;
		
		Token token
		{
			get
			{
				return tokens[i];
			}
		}
		
		public BodyCompiler (LexerResult lexerResult)
		{
			this.lexerResult = lexerResult;
		}
		
		Token NextToken()
		{
			i++;
			if (i < tokens.Length)
			{
				return token;
			}
			else
			{
				return null;
			}
		}
		
		public BodyCompilerResult Compile()
		{
			//Fetch the tokens from the lexer result
			tokens = lexerResult.tokens;
			
			for (; i < tokens.Length; NextToken())
			{
				//Check for imports
				if (ImportCheck()) continue;
				
				//Check for functions
				if (FunctionCheck()) continue;

				//Check for structs
				if (StructCheck()) continue;
				
			}
			
			return result;
		}
		
		bool StructCheck()
		{
			int previous = i;
			
			if (token is Keyword && (token as Keyword).keyword == EnumKeyword.STRUCT)
			{
				NextToken();
				if (token is Word)
				{
					Word name = token as Word;
					NextToken();
					if (token is Operator && (token as Operator).type == OperatorType.OpeningBlockBracket)
					{
						NextToken();
						int bodyLevel = 1;
						List<Token> bodyTokens = new List<Token>();
						
						
						//Get all of the tokens inside of the body
						for (; i < tokens.Length; NextToken())
						{
							if (token is Operator)
							{
								if (((Operator)token).type == OperatorType.OpeningBlockBracket)
								{
									bodyLevel++;
									bodyTokens.Add (token);
								}
								else if (((Operator)token).type == OperatorType.ClosingBlockBracket)
								{
									bodyLevel--;
									if (bodyLevel == 0)
									{
										break;
									}
								}
								else
								{
									bodyTokens.Add (token);
								}
							}
							else
							{
								bodyTokens.Add (token);
							}
						}
						
						Struct _struct = new Struct(name.raw as string, bodyTokens.ToArray());
						result.structs.Add (_struct);
						return true;
					}
				}
			}
			
			i = previous;
			return false;
		}
		
		bool ImportCheck ()
		{
			int previous = i;
			if (token is Keyword)
			{
				Keyword keyword = ((Keyword)token);
				if (((Keyword)token).keyword == EnumKeyword.IMPORT)
				{
					NextToken();
					if (token is Word)
					{
						Word word = (Word)token;
						ImportInformation importInformation = new ImportInformation((string)word.raw);
						NextToken();
						if (token is Operator && ((Operator)token).type == OperatorType.SemiColon)
						{
							result.imports.Add(importInformation);
							Logger.Log($"Added import statement: {importInformation.import}");
							return true;
						}
						else
						{
							throw new Exception ("Expected semicolon at end of import statement");
						}
					}
					else
					{
						throw new Exception ("Expected word token after import keyword!");
					}
				}
			}
			i = previous;
			return false;
		}
		
		bool FunctionCheck()
		{
			int previous = i;
			if (token is Keyword)
			{
				Keyword keyword = (Keyword)token;
				bool isPublic = false;
				//TODO: Add other types
				if (keyword.keyword == EnumKeyword.PUBLIC)
				{
					NextToken();
					isPublic = true;
				}
				
				//Check if it has the correct return type
				if (token is Word || (token is Keyword && ((Keyword)token).keyword == EnumKeyword.VOID))
				{
					NextToken();
					if (token is Word){
						string name = (string)((Word)token).raw;
						Console.WriteLine($"Function Name=\"{name}\"");
						NextToken();
						if (token is Operator && ((Operator)token).type == OperatorType.OpeningBracket)
						{
							//Function confirmed
							NextToken();
							if (token is Operator && ((Operator)token).type == OperatorType.ClosingBracket)
							{
								NextToken();
								if (token is Operator && ((Operator)token).type == OperatorType.OpeningBlockBracket)
								{
									NextToken();
									int bodyLevel = 1;
									List<Token> functionBodyTokens = new List<Token>();
									
									
									//Get all of the tokens inside of the body
									for (; i < tokens.Length; NextToken())
									{
										if (token is Operator)
										{
											if (((Operator)token).type == OperatorType.OpeningBlockBracket)
											{
												bodyLevel++;
												functionBodyTokens.Add (token);
											}
											else if (((Operator)token).type == OperatorType.ClosingBlockBracket)
											{
												bodyLevel--;
												if (bodyLevel == 0)
												{
													
													break;
												}
											}
										}
										else
										{
											functionBodyTokens.Add (token);
										}
									}
									
									
									//Create the new function
									Function function = new Function(isPublic, name, null, functionBodyTokens.ToArray());
									
									//Add the function to the BodyCompilerResult
									result.functions.Add (function);
									
								}
								else
								{
									throw new Exception ($"(Error creating function) Expected OpeningBlockBracket ... got {token.ToString()}");
								}
							}
							else
							{
								throw new Exception("Parameters aren't accepted as of this moment!");
							}
						}
					}
				}
			}
			i = previous;
			return false;
		}
	}
}

