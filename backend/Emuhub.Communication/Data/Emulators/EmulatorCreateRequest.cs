using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emuhub.Communication.Data.Emulators
{
	public class EmulatorCreateRequest
	{
		public required string Name { get; set; }
		public required string CompanyName { get; set; }
		public required string Abbreviation { get; set; }
		public required string Console { get; set; }
	}
}
