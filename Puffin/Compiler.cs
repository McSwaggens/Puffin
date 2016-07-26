using System;
using System.IO;
using static Puffin.Logger;

namespace Puffin
{
	public class Compiler
	{
		public string inputCode;
		public FileInformation inputFileInformation;
		
		public FileInformation outputFileInformation;
		
		private CompileResult compileResult;
		
		public Compiler (string file)
		{
			Log ($"Compiling {file}...");
			
			//Generate input and output file information for the compiler
			inputFileInformation = new FileInformation(file);
			GenerateOutputFileInformation();
			
			//TODO: Make this a CLI argument
			bool showIOInformation = false;
			
			if (showIOInformation)
			{
				//Show the input and output file information
				inputFileInformation.Print();
				outputFileInformation.Print();
			}
			
			FetchSourceCode();
		}
		
		/*
		* Read all text from the input file and store it into the input code variable 
		*/
		void FetchSourceCode ()
		{
			inputCode = File.ReadAllText(inputFileInformation.file);
		}
		
		//Generate our output file information from our input information
		public void GenerateOutputFileInformation()
		{
			//TODO: Accept custom output flags
			outputFileInformation = new FileInformation($"{inputFileInformation.directory}/{inputFileInformation.fileName}.p");
		}
		
		
		//Compule the program into PASM code
		/* Stages
		* Lexer - Convert the text inside of the file to tokens
		* Cross file linking & Header files - Not sure how to do at the moment
		* Pre-compile, Method and variable recognition - Identify the imports and methods.
		* Parser - Compile the tokens into PASM code
		* Constructor - Combine all the imports, functions and variables into the already generated PASM code to a single string array
		* Return the output data in a form of a CompileResult object.
		*/
		public CompileResult Compile()
		{
			//Create a new CompileResult to store our output data and errors
			//The previous compileResult will be removed upon re-compilation
			compileResult = new CompileResult();
			
			LexerResult lexerResult = Lexer.GenerateTokens(inputCode);
			
			//Print out the tokens
			lexerResult.PrintTokens();
			
			//Compile the body with the lexerResult
			BodyCompilerResult bodyCompilerResult = new BodyCompiler(lexerResult).Compile();
			
			//Print out the imports and functions returned from the body compiler
			bodyCompilerResult.PrintContents ();
			
			bodyCompilerResult.CompileFunctions();
			
			
			//Create a constructor to compile the information we've gathered into one string array
			Constructor constructor = new Constructor();
			
			//TEMPORARY
			ConstructedFile file = new ConstructedFile(inputFileInformation.fileName, bodyCompilerResult);
			
			//Pass in all our file
			constructor.Add (file);
			
			//Construct the file
			ConstructorResult constructorResult = constructor.Construct();
			
			//Print out the compiled PASM code
			constructorResult.PrintPASM();
			
			compileResult.Set (constructorResult);
			
			return compileResult;
		}
	}
}

