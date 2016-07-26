using System;
using System.IO;

namespace Puffin
{
	public class FileInformation
	{
		public string directory;
		public string file;
		public string fileName;
		public string fileExtension;
		
		public FileInformation (string file)
		{
			directory = Path.GetDirectoryName(file);
			
			this.file = file;
			fileName = Path.GetFileNameWithoutExtension(file);
			fileExtension = Path.GetExtension(file);
		}
		
		public void Print()
		{
			Console.WriteLine($"directory={directory}");
			Console.WriteLine($"file={file}");
			Console.WriteLine($"fileName={fileName}");
			Console.WriteLine($"fileExtension={fileExtension}");
		}
	}
}

