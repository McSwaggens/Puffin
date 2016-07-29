using System;
using System.Collections.Generic;

namespace Puffin
{
	public class FunctionContext
	{
		public Function function;
		public List<Variable> variables = new List<Variable>();
		
		public FunctionContext (Function function)
		{
			this.function = function;
			foreach (KeyValuePair<Type, Variable> tv in function.requiredParameters)
			{
				variables.Add (tv.Value);
			}
		}
		
		public bool DoesVariableExist (Word word, out Variable oVariable)
		{
			string name = word.raw as string;
			
			foreach (Variable variable in variables)
			{
				if (name == variable.name)
				{
					oVariable = variable;
					return true;
				}
			}
			oVariable = null;
			return false;
		}
		
		public bool DoesVariableExist (Word word)
		{
			string name = word.raw as string;
			
			foreach (Variable variable in variables)
			{
				if (name == variable.name)
				{
					return true;
				}
			}
			return false;
		}
		
		public Variable GetVariableExist (Word word)
		{
			string name = word.raw as string;
			
			foreach (Variable variable in variables)
			{
				if (name == variable.name)
				{
					return variable;
				}
			}
			throw new Exception ($"No known variable named \"{name}\"");
		}
	}
}

