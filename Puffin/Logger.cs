using System;
using System.Collections.Generic;

namespace Puffin
{
	public class Logger
	{
		public static Dictionary<LogType, string> logs = new Dictionary<LogType, string>();
		
		public static void Log (string message)
		{
			Console.WriteLine(message);
		}
		
		public static void LogWarning (string message)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			
			Console.WriteLine (message);
			
			Console.ResetColor();
		}
		
		public static void LogError (string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			
			Console.WriteLine (message);
			
			Console.ResetColor();
		}
	}
	
	public enum LogType
	{
		NORMAL, WARNING, ERROR
	}
}