using System;

namespace Puffin
{
	public class ImportInformation : IPASMRep
	{
		public string import;
		public ImportInformation (string import)
		{
			this.import = import;
		}

        public string ToPASM()
        {
			return $"im {import}"; 
        }
    }
}

