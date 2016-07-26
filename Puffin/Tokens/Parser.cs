using System;
using System.Collections.Generic;

namespace bolt
{
	public class Parser
	{
		
		public static void Parse(string text, Settings settings)
		{
			Token[] tokens = Lexer.GenerateTokens(text);
			Parse(tokens, settings);
		}
		
		public static void Parse(Token[] _tokens, Settings settings) {
			
			Token[][] TokenLines = SeperateLines (_tokens);

			foreach (Token[] tokens in TokenLines) {
				if (tokens[0] is Word)
				{
					Word wCommand = (Word)tokens[0];
					if (DefCommands.Contains((string)wCommand.raw))
					{
						List<Token> cargs = new List<Token>(tokens);
						cargs.RemoveAt(0);
						
						Command command = DefCommands.Get((string)wCommand.raw);
						command.action(cargs.ToArray());
					}
					else
					{
						Notification.Push($"Unknown command {(string)wCommand.raw}", NotificationType.ERROR);
					}
				}
				else
				{
					Notification.Push("Syntax error", NotificationType.ERROR);
				}
			}
		}
		
		private static void PrintSettings(Dictionary<string, object> settings) {
			foreach (KeyValuePair<string, object> pair in settings) {
				Console.WriteLine (pair.Key + "\t" + pair.Value);
			}
		}

		private static Token[][] SeperateLines(Token[] tokens) {
			List<Token[]> tokenLines = new List<Token[]> ();
			List<Token> currentTokenLine = new List<Token> ();
			foreach (Token token in tokens) {
				if (token is Operator && ((Operator)token).type == OperatorType.SemiColon) {
					tokenLines.Add (currentTokenLine.ToArray ());
				}
				else
					currentTokenLine.Add (token);
			}
			return tokenLines.ToArray ();
		}
	}
}

