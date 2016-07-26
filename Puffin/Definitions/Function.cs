using System;
using System.Collections.Generic;

namespace Puffin
{
	public class Function
	{
		//PASM function representing the Puffin function
		PFunction pFunction;
		
		//Whether the function can be accessed outside of the current file
		public bool isPublic = false;
		
		//Name of the function
		public string name;
		
		//Body of tokens
		private Token[] bodyTokens;
		
		//TODO: Fix
		//Required parameters of the function
		public Dictionary<Type, Variable> requiredParameters;
		
		
		public string[] PASM;
		
		public Function(bool isPublic, string name, Dictionary<Type, Variable> requiredParameters, Token[] bodyTokens)
		{
			this.isPublic = isPublic;
			this.name = name;
			this.requiredParameters = requiredParameters;
			this.bodyTokens = bodyTokens;
			pFunction = new PFunction();
		}
		
		
		public void Compile()
		{
			//TODO: Compile the guts of the function
			
			List<string> pasm = new List<string>();
			
			//Create the head of the function (point)
			pasm.Add ($"pt {pFunction.id}");
			
			
			
			pasm.Add ($"re");
			
			PASM = pasm.ToArray ();
		}
	}
}

